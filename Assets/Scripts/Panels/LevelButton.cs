using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    #region Variables
    public LevelTypes levelType;
    [SerializeField]private GameObject lockIcon;
    [SerializeField] private int levelNumber;
    #endregion
    public void OnLevelSelected()
    {
        GameManager.Instance.GetType(levelType);
        GameManager.Instance.StartQuiz();
        GameManager.Instance.GetCurrentLevelNumber(levelNumber);
        AddLogger.DisplayLog("Level type  in button: " + levelType);
    }

    public void SetupLockButton()
    {
        lockIcon.SetActive(true);
    }

    public void SetUpUnlockButton()
    {
        lockIcon.SetActive(false);
    }
}
