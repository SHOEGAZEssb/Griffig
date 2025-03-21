using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Minigames
{
  internal enum PlayerRole
  {
    Active,
    Passive,
    Neutral
  }

  internal abstract class Minigame
  {
    #region Properties

    public abstract string Name { get; }

    public KeyValuePair<Player, PlayerRole> Player { get; }

    public IPhase[] Phases { get; }

    public IPhase CurrentPhase
    {
      get => _currentPhase;
      protected set
      {
        // remove old confirmed event handler
        if (CurrentPhase != null)
          CurrentPhase.PlayerConfirmed -= CurrentPhase_PlayerConfirmed;

        _currentPhase = value;
        CurrentPhase.PlayerConfirmed += CurrentPhase_PlayerConfirmed;
        PhaseChanged?.Invoke(this, EventArgs.Empty);
      }
    }
    private IPhase _currentPhase;

    private void CurrentPhase_PlayerConfirmed(object sender, PlayerConfirmEventArgs e)
    {
      CurrentPhaseConfirmed?.Invoke(this, e);
    }

    public event EventHandler MinigameEnded;
    public event EventHandler PhaseChanged;
    public event EventHandler<PlayerConfirmEventArgs> CurrentPhaseConfirmed;

    #endregion Properties

    #region Construction

    protected Minigame(KeyValuePair<Player, PlayerRole> player)
    {
      Player = player;
      Phases = BuildPhases(player.Value);
      CurrentPhase = Phases[0];
    }

    #endregion Construction

    public void NextPhase()
    {
      var currentPhaseIndex = Array.IndexOf(Phases, CurrentPhase);
      if (currentPhaseIndex + 1 >= Phases.Length)
        MinigameEnded?.Invoke(this, EventArgs.Empty); // no phases left; game ended
      else
        CurrentPhase = Phases[currentPhaseIndex + 1];
    }

    protected abstract IPhase[] BuildPhases(PlayerRole localPlayerRole);
  }
}