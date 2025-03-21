using System.Collections.Generic;

namespace Assets.Scripts.Models.Minigames.WaveLength
{
  internal sealed class WaveLength : Minigame
  {
    #region Properties

    public const string WL_EXPLANATIONPHASE_ACTIVE = "WaveLength_ExplanationPhase_Active";
    public const string WL_EXPLANATIONPHASE_PASSIVE = "WaveLength_ExplanationPhase_Passive";
    public const string WL_INITIALINPUTPHASE_ACTIVE = "WaveLength_InitialInputPhase_Active";
    public const string WL_INITIALINPUTPHASE_PASSIVE = "WaveLength_InitialInputPhase_Passive";
    public const string WL_INPUTPHASE_ACTIVE = "WaveLength_InputPhase_Active";

    public override string Name => "Wave Length";

    #endregion Properties

    #region Construction

    public WaveLength(KeyValuePair<Player, PlayerRole> player)
      : base(player)
    { }

    #endregion Construction

    protected override IPhase[] BuildPhases(PlayerRole localPlayerRole)
    {
      var phases = new IPhase[]
      {
        localPlayerRole == PlayerRole.Active ? new GenericExplanationPhase("Explain Active WaveLength part", Player.Key, WL_EXPLANATIONPHASE_ACTIVE)
                                             : new GenericExplanationPhase("Explain Passive WaveLength part",Player.Key, WL_EXPLANATIONPHASE_PASSIVE),
        localPlayerRole == PlayerRole.Active ? new GenericExplanationPhase("Give input", Player.Key, WL_INITIALINPUTPHASE_ACTIVE)
                                             : new GenericExplanationPhase("Wait for initial input", Player.Key, WL_INITIALINPUTPHASE_PASSIVE, autoConfirm: true),
        localPlayerRole == PlayerRole.Active ? new GenericExplanationPhase("Wait for passive player input", Player.Key, WL_INPUTPHASE_ACTIVE, autoConfirm: true)
                                             : new WaveLengthInputPhase(Player.Key)
      };

      return phases;
    }
  }
}
