using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelButton : MonoBehaviour
{
    #region Variables
    public LevelTypes levelType;
    [SerializeField]private GameObject lockIcon;
    [SerializeField] private int levelNumber;
    [SerializeField] private Button myButton;
    #endregion

    private void Start()
    {
        ColorBlock cb = myButton.colors;
        cb.disabledColor = cb.normalColor;
        myButton.colors = cb;
    }

    public void OnLevelSelected()
    {
        AudioManager.Instance.PlayClickSound();
        GameManager.Instance.GetType(levelType);
        GameManager.Instance.StartQuiz();
        GameManager.Instance.GetCurrentLevelNumber(levelNumber);
    }

    public void SetupLockButton()
    {
        lockIcon.SetActive(true);
        myButton.interactable = false;
    }

    public void SetUpUnlockButton()
    {
        lockIcon.SetActive(false);
        myButton.interactable = true;
    }
}
