using System;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Models.Profile
{
  /// <summary>
  /// Manager for saving / loading the local player profile.
  /// </summary>
  internal class ProfileManager
  {
    #region Singleton

    /// <summary>
    /// Gets the instance of the <see cref="ProfileManager"/>.
    /// </summary>
    public static ProfileManager Instance => _instance ??= new ProfileManager();
    private static ProfileManager _instance;

    #endregion Singleton

    #region Properties

    /// <summary>
    /// The player profile.
    /// </summary>
    public Profile Profile { get; }

    #endregion Properties

    #region Construction

    private ProfileManager()
    {
      Profile = LoadProfileFromDisk();
    }

    #endregion Construction

    private static Profile LoadProfileFromDisk()
    {
      var path = Application.persistentDataPath + "/profile.json";
      try
      {
        // profile exists; load it
        if (File.Exists(path))
          return JsonUtility.FromJson<Profile>(File.ReadAllText(path));
      }
      catch (Exception ex)
      {
        // todo log
      }

      // profile does not exist or is corrupted; create new and save
      var profile = new Profile();
      SaveProfileToDisk(profile);
      return profile;
    }

    /// <summary>
    /// Saves the current profile to disk.
    /// </summary>
    public void SaveProfileToDisk()
    {
      SaveProfileToDisk(Profile);
    }

    private static void SaveProfileToDisk(Profile profile)
    {
      var path = Application.persistentDataPath + "/profile.json";
      try
      {
        var json = JsonUtility.ToJson(profile, prettyPrint: true);
        File.WriteAllText(path, json);
      }
      catch (Exception ex)
      {
        // todo log
      }
    }
  }
}