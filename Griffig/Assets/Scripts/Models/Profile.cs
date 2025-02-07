using System;

/// <summary>
/// Profile of a <see cref="Player"/>.
/// This represents more like an "account" and not a
/// game participant.
/// </summary>
internal class Profile
{
  #region Properties

  /// <summary>
  /// Name of the profile.
  /// </summary>
  public string Name { get; set; }

  /// <summary>
  /// 'Unique' profile id.
  /// </summary>
  private Guid _id;

  #endregion Properties
}