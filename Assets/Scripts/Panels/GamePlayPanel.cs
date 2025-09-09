using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GamePlayPanel : MonoBehaviour
{
    #region Variables/GameObjects
    public static GamePlayPanel Instance;
    [SerializeField] private TextMeshProUGUI quesText;
    [SerializeField] private TextMeshProUGUI levelName;
    [SerializeField] private List<TextMeshProUGUI> optionsText;
    [SerializeField] private List<GameObject> buttons;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject correctCheckBox;
    [SerializeField] private GameObject wrongCheckBox;
    [SerializeField] private TextMeshProUGUI queNoText;
    private string _selectedText;
    public Button selectedButton;
    private float _typingSpeed = 0.025f;
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        TurnNextButtonOff();
    }


    public void ShowNextQuestion(string ques, List<string> options, int num)
    {
        levelName.text = "" + GameManager.Instance.currentLevelType.ToString();
        ResetButtons();
        queNoText.text = " ";
        queNoText.text = ""+num;
        StopAllCoroutines();
        StartCoroutine(TypeText(ques, options));
    }

    private IEnumerator TypeText(string FullText, List<string> options)
    {
        quesText.text = " ";
        foreach(char c in FullText)
        {
            quesText.text += c;
            yield return new WaitForSeconds(_typingSpeed);
        }
        SetOptions(options);
    }

    private void SetOptions(List<string> options)
    {
        for (int i = 0; i < options.Count; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
            buttons[i].SetActive(true);
        }
        StartCoroutine(OptionsLoop(options));
    }

    private IEnumerator OptionsLoop(List<string> options)
    {
        for (int i = 0; i < options.Count; i++)
        {
            StartCoroutine(TypeOptions(options[i], optionsText[i]));
        }
        yield return new WaitForSeconds(0.5f);
        TurnButtonsTrue(options);
    }

    private void TurnButtonsTrue(List<string> options)
    {
        for(int i=0;i<options.Count;i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }
    private IEnumerator TypeOptions(string option,TextMeshProUGUI optionText)
    {
        optionText.text = "";
        foreach(char c in option)
        {
            optionText.text += c;
            yield return new WaitForSeconds(_typingSpeed);
        }
    }

    private void ResetButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetActive(false);
            optionsText[i].text = " ";
        }
    }

    private void ResetButtonImages()
    {
        foreach (var button in buttons)
        {
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.color = Color.white;
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.color = Color.red;
        }
        LockButtons(true);
    }

    public void OnAnswerClicked(Button clickedButton)
    {
        ResetButtonImages();
        _selectedText = clickedButton.GetComponentInChildren<TextMeshProUGUI>().text;
        nextButton.interactable = true;
        Image buttonImage = clickedButton.GetComponent<Image>();
        TextMeshProUGUI buttonText = clickedButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonImage.color = Color.red;
        buttonText.color = Color.white;
        selectedButton = clickedButton;
    }

    public void OnNextButtonClick()
    {
        OnClick(selectedButton);
        StartCoroutine(AfterNextButton());
    }

    private IEnumerator AfterNextButton()
    {
        LockButtons(false);
        yield return new WaitForSeconds(0.25f);
        GameManager.Instance.OnAnswerSelected(_selectedText);
        ResetButtonImages();
    }

    public void OnClick(Button myButton)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(myButton.transform.DOScale(new Vector3(1.2f, 2.0f, 0), 0.15f));
        seq.Append(myButton.transform.DOScale(new Vector3(1.0f, 1.0f, 0), 0.075f));
    }

    public void MoveCheckBox(bool condition)
    {
        if(condition)
        {
            correctCheckBox.SetActive(true);
            return;
        }
        wrongCheckBox.SetActive(true);
    }

    public void ResetCheckBox()
    {
        correctCheckBox.SetActive(false);
        wrongCheckBox.SetActive(false);
    }

    private void LockButtons(bool Condition)
    {
        foreach (var button in buttons)
        {
            button.GetComponent<Button>().interactable = Condition;
        }
    }
    public void TurnNextButtonOff()
    {
        nextButton.interactable = false;
    }
}
