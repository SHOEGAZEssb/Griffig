using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Minigames
{
  internal interface IPhase
  {
    /// <summary>
    /// Name of the phase.
    /// </summary>
    string Name { get; }

    Player Player { get; }

    event EventHandler<PlayerConfirmEventArgs> PlayerConfirmed;

    void Confirm(PlayerConfirmEventArgs eventArgs);
  }
}