using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Variables

    public static AudioManager Instance;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioClip typingSound;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip winSound;
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        UpdateMusic();
    }

    public void UpdateMusic()
    {
        int num = SaveManager.Instance.GetAudioStatus();
        AddLogger.DisplayLog("num value is: " + num);
        if (num == 1)
        {
            musicAudioSource.clip = gameMusic;
            musicAudioSource.loop = true;
            musicAudioSource.Play();
        }
        else
        {
            musicAudioSource.Stop();
            musicAudioSource.clip = null;
            musicAudioSource.loop = false;
        }
    }

    public void PlayTypingSound()
    {
        int num = SaveManager.Instance.GetSfxStatus();
        if (num == 1)
        {
            sfxAudioSource.clip = typingSound;
            sfxAudioSource.loop = true;
            sfxAudioSource.Play();
        }
    }

    public void StopTypingSound()
    {
        sfxAudioSource.Stop();
        sfxAudioSource.loop = false;
        sfxAudioSource.clip = null;
    }

    public void PlayClickSound()
    {
        int num = SaveManager.Instance.GetSfxStatus();
        if (num == 1)
        {
            sfxAudioSource.PlayOneShot(clickSound);
        }
    }

    public void PlayWinSound()
    {
        int num = SaveManager.Instance.GetSfxStatus();
        if (num == 1)
        {
            sfxAudioSource.clip = winSound;
            sfxAudioSource.loop = true;
            sfxAudioSource.Play();
        }
    }

    public void StopWinSound()
    {
        sfxAudioSource.Stop();
        sfxAudioSource.clip = null;
        sfxAudioSource.loop = false;
    }
}
