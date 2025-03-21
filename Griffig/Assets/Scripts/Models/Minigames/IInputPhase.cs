using System;

namespace Assets.Scripts.Models.Minigames
{
  internal interface IInputPhase<T> : ITimedPhase where T : struct
  {
    T? Input { get; set; }
  }
}
