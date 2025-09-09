using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class NextLevelPopup : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject levelPopUp;
    #endregion

    private void OnEnable()
    {
        MoveLevelPopUp(0);
    }

    private void MoveLevelPopUp(int val)
    {
        levelPopUp.GetComponent<RectTransform>().DOAnchorPos(new Vector3(val, 0, 0), 1.25f);
    }

    private void ResetPostion(GameObject obj)
    {
        RectTransform rect = obj.GetComponent<RectTransform>();
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(950, 0, 0);
    }

    public void OnRetryButtonClick()
    {
        StartCoroutine(ToDoOnRetry());
    }

    private IEnumerator ToDoOnRetry()
    {
        MoveLevelPopUp(-950);
        yield return new WaitForSeconds(1.75f);
        ResetPostion(levelPopUp);
        UIManager.Instance.OnRetryButtonClick();
       
    }

    public void OnNextButtonClick()
    {
        StartCoroutine(ToDoNextButton());
    }

    private IEnumerator ToDoNextButton()
    {
        MoveLevelPopUp(-950);
        yield return new WaitForSeconds(1.75f);
        ResetPostion(levelPopUp);
        UIManager.Instance.OnNextLevelButtonClick();
    }

    public void OnMainMenuclick()
    {
        StartCoroutine(ToDoMainMenu());
    }

    private IEnumerator ToDoMainMenu()
    {
        MoveLevelPopUp(-950);
        yield return new WaitForSeconds(1.75f);
        ResetPostion(levelPopUp);
        UIManager.Instance.OnMainMenuClick();
    }
}
