using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    #region Variables/Game Objects 
    public static UIManager Instance;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject blockScreen;
    [SerializeField] private GameObject levelSelectionScreen;
    [SerializeField] private GameObject gamePlayScreen;
    [SerializeField] private GameObject retryScreen;
    #endregion

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }
        
    public void OnSettingsButtonClick()
    {
        blockScreen.SetActive(true);
        settingsMenu.SetActive(true);
    }

    public void OnSettingsCrossButtonClick()
    {
        settingsMenu.SetActive(false);
        blockScreen.SetActive(false);
    }

    public void OnStartButtonClick()
    {
        mainMenu.SetActive(false);
        levelSelectionScreen.SetActive(true);
        LevelsPanel.Instance.SetUnlockLevels();
    }

    public void OnLevelButtonClicked()
    {
        levelSelectionScreen.SetActive(false);
        gamePlayScreen.SetActive(true);
    }

    public void TurnOnRetryPanel()
    {
        gamePlayScreen.SetActive(false);
        retryScreen.SetActive(true);
    }
    
    public void OnRetryButtonClick()
    {
        retryScreen.SetActive(false);
        gamePlayScreen.SetActive(true);
        GameManager.Instance.RetryGame();
    }

    public void OnMainMenuClick()
    {
        retryScreen.SetActive(false);
        levelSelectionScreen.SetActive(true);
    }
}
