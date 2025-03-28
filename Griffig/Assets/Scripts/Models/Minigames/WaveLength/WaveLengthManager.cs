using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Minigames.WaveLength
{
  internal class WaveLengthManager
  {
    private readonly IDictionary<Player, PlayerRole> _players;
    private readonly IEnumerable<WaveLength> _gameInstances;
    private readonly WaveLength _hostInstance;
    private List<Player> _confirmedPlayers = new List<Player>();

    public WaveLengthManager(IEnumerable<Player> players)
    {
      if (players == null)
        throw new ArgumentNullException(nameof(players));
      if (!players.Any())
        throw new ArgumentException("No players", nameof(players));

      _players = AssignPlayerRoles(players);
      _gameInstances = _players.Select(kvp =>
      {
        var wl = new WaveLength(kvp);
        wl.CurrentPhaseConfirmed += GameInstance_CurrentPhaseConfirmed;
        return wl;
      });

      _hostInstance = _gameInstances.Where(i => i.Player.Key.IsLocal).First();
    }

    private void GameInstance_CurrentPhaseConfirmed(object sender, PlayerConfirmEventArgs e)
    {
      if (!_confirmedPlayers.Contains(e.Player))
        _confirmedPlayers.Add(e.Player);

      if (_confirmedPlayers.Count == _players.Count)
      {
        foreach (var instance in _gameInstances)
          instance.NextPhase();

        _confirmedPlayers = new List<Player>();
      }
    }

    private static IDictionary<Player, PlayerRole> AssignPlayerRoles(IEnumerable<Player> players)
    {
      var dict = new Dictionary<Player, PlayerRole>();
      var rng = new Random(DateTime.Now.Ticks.GetHashCode());
      var activePlayerIndex = rng.Next(0, players.Count());
      foreach (var player in players)
      {
        dict.Add(player, players.ElementAt(activePlayerIndex) == player ? PlayerRole.Active : PlayerRole.Passive);
      }

      return dict;
    }
  }
}
