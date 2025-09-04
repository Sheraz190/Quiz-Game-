using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region Variables

    public static SaveManager Instance;
    private string _musicStatus = "MusicStatus";
    private string _unlockedLEvels="UnlockedLevels";

    #endregion

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        if(!PlayerPrefs.HasKey(_unlockedLEvels))
        {
            SetUnlockedLevel(1);
        }
    }

    public void SaveAudioStatus()
    {
        PlayerPrefs.SetInt(_musicStatus, 0);
        PlayerPrefs.Save();
    }

    public int GetAudioStatus()
    {
        int audioStatus = PlayerPrefs.GetInt(_musicStatus, 4);
        return audioStatus;
    }

    public void SetUnlockedLevel(int num)
    {
        PlayerPrefs.SetInt(_unlockedLEvels, num);
        PlayerPrefs.Save();
    }

    public int GetUnlockedLevels()
    {
        int latestUnlockedLevel = PlayerPrefs.GetInt(_unlockedLEvels, 0);
        return latestUnlockedLevel;
    }
}
