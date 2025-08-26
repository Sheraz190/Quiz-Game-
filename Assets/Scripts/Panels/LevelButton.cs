using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    #region Variables
    public LevelTypes levelType;
    [SerializeField]private GameObject lockIcon;
    #endregion
    public void OnLevelSelected()
    {
        GameManager.Instance.GetType(levelType);
        GameManager.Instance.StartQuiz();
    }

    public void SetupButton()
    {
        lockIcon.SetActive(true);
    }
}
