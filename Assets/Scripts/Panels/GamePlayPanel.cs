using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GamePlayPanel : MonoBehaviour
{
    #region Variables/GameObjects
    public static GamePlayPanel Instance;
    [SerializeField] private TextMeshProUGUI quesText;
    [SerializeField] private TextMeshProUGUI levelName;
    [SerializeField] private List<TextMeshProUGUI> optionsText;
    [SerializeField] private List<GameObject> buttons;
    [SerializeField] private Button nextButton;
    private string _selectedText;
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

    public void ShowNextQuestion(string ques, List<string> options,int num)
    {
        levelName.text = "" + GameManager.Instance.currentLevelType.ToString();
        ResetButtons();
        quesText.text =num+".  "+ "" + ques;
        for (int i = 0; i < options.Count; i++)
        {
            buttons[i].SetActive(true);
            optionsText[i].text = options[i];
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
        foreach(var button in buttons)
        {
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.fillCenter = true;
        }
    }

    public void OnAnswerClicked(Button clickedButton)
    {
        ResetButtonImages();
        _selectedText = clickedButton.GetComponentInChildren<TextMeshProUGUI>().text;
        nextButton.interactable = true;
        Image buttonImage = clickedButton.GetComponent<Image>();
        buttonImage.fillCenter = false;
    }

    public void OnNextButtonClick()
    { 
        GameManager.Instance.OnAnswerSelected(_selectedText);
        ResetButtonImages();
    }

    public void TurnNextButtonOff()
    {
        nextButton.interactable = false;
    }    
}
