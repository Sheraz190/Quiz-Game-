using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GamePlayPanel : MonoBehaviour
{
    #region Variables/GameObjects
    public static GamePlayPanel Instance;
    private List<Questions> _questions = new List<Questions>();
    private List<string> _options = new List<string>();
    [SerializeField] private TextMeshProUGUI _quesText;
    [SerializeField] private List<TextMeshProUGUI> _optionsText;
    [SerializeField] private List<GameObject> buttons;
    #endregion

    private void Start()
    {
        //GetQuestion();
        Instance = this;
        GameManager.Instance.StartQuiz();
    }

    private void GetQuestion()
    {
        for (int i = 0; i < 10; i++)
        {
            _questions.Add(GameManager.Instance._questionsList[i]);
        }
        _options = GameManager.Instance.GetAnswerOfQuestion(_questions[0]);
        _quesText.text = " " + _questions[0].questionText;
        _optionsText[0].text = _options[0];
        _optionsText[1].text = "" + _options[1];
    }

    //private void ShowQuestionOptions()
    //{
    //    _quesText.text = " " + _questions[0].questionText;
    //    _optionsText[0].text = _options[0];
    //    _optionsText[1].text = "" + _options[1];
    //}

    public void ShowNextQuestion(string ques, List<string> options)
    {
        _quesText.text = "" + ques;
        for (int i = 0; i < options.Count; i++)
        {
            _optionsText[i].text = options[i];
            buttons[i].SetActive(true);
        }
    }

    private void ResetButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetActive(false);
            _optionsText[i].text = " ";
        }
    }

    public void OnAnswerClicked(Button clickedButton)
    {
        string selectedText = clickedButton.GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log("Button clicked: " + selectedText);
    }
}
