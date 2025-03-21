namespace Assets.Scripts.Models.Minigames
{
  internal class GenericExplanationPhase : PhaseBase, IExplanationPhase
  {
    public override string Name { get; }

    public string Explanation { get; }

    public GenericExplanationPhase(string name, Player player, string explanation, bool autoConfirm = false)
      : base(player)
    {
      Name = name;
      Explanation = explanation;

      if (autoConfirm)
        Confirm(new PlayerConfirmEventArgs(player));
    }
  }
}
