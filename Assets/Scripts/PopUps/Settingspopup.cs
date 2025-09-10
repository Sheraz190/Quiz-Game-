using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
public class Settingspopup : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject settingPopup;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle sfxToggle;
    #endregion

    private void OnEnable()
    {
        MoveLevelPopUp(0, 0, 1, 1);
        UpdateToggles();
    }

    private void UpdateToggles()
    {
        int sfxnum = SaveManager.Instance.GetSfxStatus();
        if (sfxnum == 1)
        {
            sfxToggle.isOn = true;
        }
        else
        {
            sfxToggle.isOn = false;
        }
        UpdateMusicToggle();
    }

    private void UpdateMusicToggle()
    {
        int num = SaveManager.Instance.GetAudioStatus();
        if (num == 1)
        {
            musicToggle.isOn = true;
        }
        else
        {
            musicToggle.isOn = false;
        }
    }
    private void MoveLevelPopUp(int valX, int valY, float scaleX, float scaleY)
    {
        Sequence seq = DOTween.Sequence();
        seq.Join(settingPopup.GetComponent<RectTransform>().DOAnchorPos(new Vector3(valX, valY, 0), 0.25f));
        seq.Join(settingPopup.GetComponent<RectTransform>().DOScale(new Vector3(scaleX, scaleY, 1), 0.25f));
    }


    public void OnCrossButtonClick()
    {
        StartCoroutine(ToDoCrossButton());
    }

    private IEnumerator ToDoCrossButton()
    {
        MoveLevelPopUp(-425, 900, 0.2f, 0.2f);
        yield return new WaitForSeconds(0.23f);
        settingsPanel.SetActive(false);
    }
}
