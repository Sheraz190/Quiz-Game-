using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    #region Variables/Game Objects 

    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _blockScreen;
    [SerializeField] private GameObject _levelSelectionScreen;
    [SerializeField] private GameObject _gamePlayScreen;

    #endregion
    public void OnSettingsButtonClick()
    {
        _blockScreen.SetActive(true);
        _settingsMenu.SetActive(true);
    }

    public void OnSettingsCrossButtonClick()
    {
        _settingsMenu.SetActive(false);
        _blockScreen.SetActive(false);
    }

    public void OnStartButtonClick()
    {
        _mainMenu.SetActive(false);
        _levelSelectionScreen.SetActive(true);
        LevelsPanel.Instance.SetUnlockLevels();
    }

    public void OnLevelButtonClicked()
    {
        _levelSelectionScreen.SetActive(false);
        _gamePlayScreen.SetActive(true);
    }
}
