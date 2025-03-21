using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Minigames
{
  internal class GenericScoreDisplayPhase : PhaseBase, IScoreDisplayPhase
  {
    public override string Name => "WaveLength_ScoringPhase";

    public GenericScoreDisplayPhase(Player player)
      : base(player) 
    { }
  }
}
