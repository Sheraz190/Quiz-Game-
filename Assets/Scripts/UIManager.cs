using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    #region Variables/Game Objects 
    public static UIManager Instance;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject levelSelectionScreen;
    [SerializeField] private GameObject gamePlayScreen;
    [SerializeField] private GameObject retryScreen;
    [SerializeField] private GameObject nextLevelScreen;
    [SerializeField] private GameObject exitScreen;
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
        settingsMenu.SetActive(true);
    }

    public void OnSettingsCrossButtonClick()
    {
        settingsMenu.SetActive(false);
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
        retryScreen.SetActive(true);
    }
    
    public void OnRetryButtonClick()
    {
        retryScreen.SetActive(false);
        GameManager.Instance.RetryGame();
    }

    public void OnMainMenuClick()
    {
        TurnAllScreensOff();
        levelSelectionScreen.SetActive(true);
        LevelsPanel.Instance.SetUnlockLevels();
    }

    public void OnLevelCompletedScreen()
    { 
        nextLevelScreen.SetActive(true);
    }

    public void OnNextLevelButtonClick()
    {
        nextLevelScreen.SetActive(false);
        GameManager.Instance.StartQuiz();
    }

    public void OnGameComplete()
    {
        exitScreen.SetActive(true);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void TurnAllScreensOff()
    {
        mainMenu.SetActive(false);
        levelSelectionScreen.SetActive(false);
        gamePlayScreen.SetActive(false);
        retryScreen.SetActive(false);
        nextLevelScreen.SetActive(false);
        exitScreen.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void TurnLevelScreenOn()
    {
        TurnAllScreensOff();
        levelSelectionScreen.SetActive(true);
    }

    public void TurnStartScreenOn()
    {
        TurnAllScreensOff();
        mainMenu.SetActive(true);
    }
}
