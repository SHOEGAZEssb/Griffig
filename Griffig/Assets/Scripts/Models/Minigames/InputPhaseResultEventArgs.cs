using System;

namespace Assets.Scripts.Models.Minigames
{
  internal class InputPhaseResultEventArgs<T> : PlayerConfirmEventArgs where T : struct
  {
    #region Properties

    public T? Input { get; }

    #endregion Properties

    #region Construction

    public InputPhaseResultEventArgs(T? input, Player player)
      : base(player)
    {
      Input = input;
    }

    #endregion Construction
  }
}
