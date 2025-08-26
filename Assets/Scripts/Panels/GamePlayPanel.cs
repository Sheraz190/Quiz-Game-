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
    [SerializeField] private TextMeshProUGUI _levelName;
    [SerializeField] private List<TextMeshProUGUI> _optionsText;
    [SerializeField] private List<GameObject> buttons;
    #endregion

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameManager.Instance.StartQuiz();
    }

    public void ShowNextQuestion(string ques, List<string> options)
    {
        _levelName.text = "" + GameManager.Instance._currentLevelType.ToString();
        ResetButtons();
        _quesText.text = "" + ques;
        for (int i = 0; i < options.Count; i++)
        {
            buttons[i].SetActive(true);
            _optionsText[i].text = options[i];
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
        GameManager.Instance.OnAnswerSelected(selectedText);
        
    }
}
