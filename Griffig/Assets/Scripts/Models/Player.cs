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
  public bool IsLocal { get; }

  /// <summary>
  /// Current score of the player.
  /// </summary>
  public int Score { get; set; }

  #endregion Properties

  #region Construction

  /// <summary>
  /// Constructor for creating a player from a <see cref="Profile"/>.
  /// </summary>
  /// <param name="profile">Profile belonging to this player.</param>
  /// <exception cref="ArgumentNullException">If <paramref name="profile"/> is null.</exception>
  internal Player(Profile profile)
    : this(profile?.Name)
  {
    IsLocal = true;
  }

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="name">Name of the player.</param>
  /// <exception cref="ArgumentNullException">If <paramref name="name"/> is null.</exception>
  public Player(string name)
  {
    Name = name ?? throw new ArgumentNullException(nameof(name));
  }

  #endregion Construction
}
