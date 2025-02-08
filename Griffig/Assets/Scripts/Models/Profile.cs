using System;

/// <summary>
/// Profile of a <see cref="Player"/>.
/// Represents an account rather than a game participant.
/// </summary>
[Serializable]
internal class Profile
{
  #region Properties

  /// <summary>
  /// Name of the profile.
  /// Defaults to "Unnamed Profile" if empty.
  /// </summary>
  public string Name
  {
    get => _name;
    set => _name = string.IsNullOrEmpty(value) ? "Unnamed Profile" : value;
  }
  private string _name = "Unnamed Profile";

  /// <summary>
  /// 'Unique' profile ID (stored as string for JSON compatibility).
  /// </summary>
  public string ID { get; private set; }

  #endregion Properties

  #region Construction

  /// <summary>
  /// Default constructor ensures ID is always initialized.
  /// </summary>
  public Profile()
  {
    ID ??= Guid.NewGuid().ToString();
  }

  #endregion Construction
}