using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
