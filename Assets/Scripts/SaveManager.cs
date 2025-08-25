using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region Variables

    public static SaveManager Instance;
    private string _musicStatus = "MusicStatus";
    private string _unlockedLEvels="UnlockedLevels";

    #endregion

    private void Start()
    {
        Instance = this;
        SetUnlockedLevel();
    }

    public void SaveAudioStatus()
    {
        PlayerPrefs.SetInt(_musicStatus, 0);
        PlayerPrefs.Save();
        AddLogger.DisplayLog("Audi updated");
    }

    public int GetAudioStatus()
    {
        int audioStatus = PlayerPrefs.GetInt(_musicStatus, 1);
        return audioStatus;
    }

    public void SetUnlockedLevel()
    {
        PlayerPrefs.SetInt(_unlockedLEvels, 7);
        PlayerPrefs.Save();
    }

    public int GetUnlockedLevels()
    {
        int latestUnlockedLevel = PlayerPrefs.GetInt(_unlockedLEvels, 0);
        return latestUnlockedLevel;
    }

}
