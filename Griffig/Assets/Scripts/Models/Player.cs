using Assets.Scripts.Models.Profile;
using System;

/// <summary>
/// Player participating in a game.
/// </summary>
public class Player
{
  #region Properties

  /// <summary>
  /// Name of the player.
  /// </summary>
  public string Name { get; }

  /// <summary>
  /// Indicates if this is the player of this device.
  /// </summary>
  public bool IsLocal => ProfileManager.Instance.Profile.ID == _profileID;
  private readonly string _profileID;

  /// <summary>
  /// Current score of the player.
  /// </summary>
  public int Score { get; set; }

  #endregion Properties

  #region Construction

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="name">Name of the player.</param>
  /// <param name="profileID">Profile ID of the profile this player belongs to.</param>
  /// <exception cref="ArgumentNullException">If <paramref name="name"/> is null.</exception>
  public Player(string name, string profileID)
  {
    Name = name ?? throw new ArgumentNullException(nameof(name));
    _profileID = profileID;
  }

  #endregion Construction
}
