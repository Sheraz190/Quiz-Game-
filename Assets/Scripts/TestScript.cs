using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.InputSystem;

public class TestScript : MonoBehaviour
{
    [SerializeField] private GameObject hookImage;
    [SerializeField] private GameObject congratsText;
    private void OnEnable()
    {
        RotateImage();
    }

    private void RotateImage()
    {
        AddLogger.DisplayLog("Image rotate method called");
        Sequence seq = DOTween.Sequence();
        seq.Append(congratsText.transform.DOScale(new Vector3(2.75f, 2.75f, 0), 1.5f));
        seq.Append(hookImage.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 75, 0), 0.25f));
        seq.Append(hookImage.GetComponent<RectTransform>().DORotate(new Vector3(0, 75, 0), 0.25f));
        seq.Append(hookImage.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 0), 1.0f));
        ResetPositions();
    }

    private void ResetPositions()
    {
        hookImage.GetComponent<RectTransform>().localPosition = new Vector3(0, 30, 0);
        hookImage.GetComponent<RectTransform>().localRotation = Quaternion.Euler (0, 0, 0);
        congratsText.transform.localScale = Vector3.one;
    }
}
