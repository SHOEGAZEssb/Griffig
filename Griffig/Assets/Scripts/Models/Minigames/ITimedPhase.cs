using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Minigames
{
  internal interface ITimedPhase : IPhase
  {
    TimeSpan Time { get; }

    void TimeOut();
  }
}