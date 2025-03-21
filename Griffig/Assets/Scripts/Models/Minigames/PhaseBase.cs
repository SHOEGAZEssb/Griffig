using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Minigames
{
  internal abstract class PhaseBase : IPhase
  {
    public abstract string Name { get; }

    public Player Player { get; }

    public event EventHandler<PlayerConfirmEventArgs> PlayerConfirmed;

    protected PhaseBase(Player player)
    {
      Player = player ?? throw new ArgumentNullException(nameof(player));
    }

    public void Confirm(PlayerConfirmEventArgs eventArgs)
    {
      PlayerConfirmed?.Invoke(this, eventArgs);
    }
  }
}
