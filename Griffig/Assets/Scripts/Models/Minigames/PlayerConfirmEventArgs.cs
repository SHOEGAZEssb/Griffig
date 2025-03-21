using System;

namespace Assets.Scripts.Models.Minigames
{
  internal class PlayerConfirmEventArgs : EventArgs
  {
    #region Properties

    public Player Player { get; }

    #endregion Properties

    #region Construction

    public PlayerConfirmEventArgs(Player player)
    {
      Player = player ?? throw new ArgumentNullException(nameof(player));
    }

    #endregion Construction
  }
}
