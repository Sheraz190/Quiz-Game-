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
        
    }

    public void ShowNextQuestion(string ques, List<string> options)
    {
        levelName.text = "" + GameManager.Instance.currentLevelType.ToString();
        ResetButtons();
        quesText.text = "" + ques;
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

    public void OnAnswerClicked(Button clickedButton)
    {
        string selectedText = clickedButton.GetComponentInChildren<TextMeshProUGUI>().text;
        GameManager.Instance.OnAnswerSelected(selectedText);
    }
}
