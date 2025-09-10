using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region Variables

    public static SaveManager Instance;
    private string _musicStatus = "MusicStatus";
    private string _unlockedLEvels="UnlockedLevels";
    private string _soundStatus = "SoundStatus";

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
        if (!PlayerPrefs.HasKey(_unlockedLEvels))
        {
            SetUnlockedLevel(1);
        }
    }

    public void SaveAudioStatus(int num)
    {
        PlayerPrefs.SetInt(_musicStatus, num);
        PlayerPrefs.Save();
    }

    public int GetAudioStatus()
    {
        int audioStatus = PlayerPrefs.GetInt(_musicStatus, 4);
        return audioStatus;
    }

    public void SaveSfxStatus(int num)
    {
        PlayerPrefs.SetInt(_soundStatus, num);
        PlayerPrefs.Save();
    }
    public int GetSfxStatus()
    {
        int sfxStatus = PlayerPrefs.GetInt(_soundStatus, 4);
        return sfxStatus;
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
