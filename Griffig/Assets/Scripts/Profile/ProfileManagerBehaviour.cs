using Assets.Scripts.Models.Profile;
using UnityEngine;

/// <summary>
/// Script for managing a player profile.
/// </summary>
public class ProfileManagerBehaviour : MonoBehaviour
{
  #region Properties

  /// <summary>
  /// Editable name of the profile.
  /// </summary>
  public string Name
  {
    get => _profileManager.Profile.Name;
    set => _profileManager.Profile.Name = value;
  }

  private ProfileManager _profileManager;

  #endregion Properties

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _profileManager = ProfileManager.Instance;
  }

  /// <summary>
  /// Confirms the changes and saves the profile.
  /// </summary>
  public void Confirm()
  {
    _profileManager.SaveProfileToDisk();
  }
}
