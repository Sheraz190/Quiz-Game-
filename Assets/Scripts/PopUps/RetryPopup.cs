using UnityEngine;
using System.Collections;
using DG.Tweening;
public class RetryPopup : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject retryPopup;
    #endregion

    private void OnEnable()
    {
        MoveLevelPopUp(0);
    }

    private void MoveLevelPopUp(int val)
    {
        retryPopup.GetComponent<RectTransform>().DOAnchorPos(new Vector3(val, 0, 0), 0.4f).SetEase(Ease.OutBounce);
    }

    private void ResetPostion()
    {
        retryPopup.GetComponent<RectTransform>().anchoredPosition = new Vector3(950, 0, 0);
    }

    public void OnRetryButtonClick()
    {
        StartCoroutine(ToDoOnRetry());
    }

    private IEnumerator ToDoOnRetry()
    {
        MoveLevelPopUp(-950);
        yield return new WaitForSeconds(1.75f);
        ResetPostion();
        UIManager.Instance.OnRetryButtonClick();
    }

    public void OnMainMenuclick()
    {
        StartCoroutine(ToDoMainMenu());
    }

    private IEnumerator ToDoMainMenu()
    {
        MoveLevelPopUp(-950);
        yield return new WaitForSeconds(1.75f);
        ResetPostion();
        UIManager.Instance.OnMainMenuClick();
    }
}
