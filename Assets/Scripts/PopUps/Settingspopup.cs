using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
public class Settingspopup : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject settingPopup;
    [SerializeField] private GameObject settingsPanel;
    #endregion

    private void OnEnable()
    {
        MoveLevelPopUp(0,0,1,1);
    }

    private void MoveLevelPopUp(int valX,int valY,float scaleX,float scaleY)
    {
        Sequence seq = DOTween.Sequence();
        seq.Join(settingPopup.GetComponent<RectTransform>().DOAnchorPos(new Vector3(valX, valY, 0), 0.75f));
        seq.Join(settingPopup.GetComponent<RectTransform>().DOScale(new Vector3(scaleX, scaleY, 1), 0.75f));
    }

    private void ResetPostion()
    {
        RectTransform rect = settingPopup.GetComponent<RectTransform>();
        settingPopup.GetComponent<RectTransform>().anchoredPosition = new Vector3(-425,900, 0);
        settingPopup.GetComponent<RectTransform>().localScale = new Vector3(0.2f, 0.2f, 0);
    }

    public void OnCrossButtonClick()
    {
        StartCoroutine(ToDoCrossButton());
    }

    private IEnumerator ToDoCrossButton()
    {
        MoveLevelPopUp(-425,900,0.2f,0.2f);
        yield return new WaitForSeconds(0.55f);
        //ResetPostion();
        settingsPanel.SetActive(false);
    }
}
