using System;

namespace Assets.Scripts.Models.Minigames.WaveLength
{
  internal class WaveLengthInputPhase : PhaseBase, IInputPhase<int>
  {
    public int? Input
    {
      get => _input;
      set
      {
        if (value < 0 || value > 100)
          return;
        _input = value;
      }
    }
    private int? _input;

    public TimeSpan Time => TimeSpan.FromSeconds(60);

    public override string Name => "WaveLength_InputPhase_Passive";

    #region Construction

    public WaveLengthInputPhase(Player player)
      : base(player)
    {

    }

    #endregion Construction

    public void TimeOut()
    {
      Confirm(new InputPhaseResultEventArgs<int>(Input, Player));
    }
  }
}
