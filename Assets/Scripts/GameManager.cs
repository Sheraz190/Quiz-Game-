using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    #region Variables/ GameObjects

    public static GameManager Instance;
    [SerializeField] private GameLevelsData _gameLevelData;
    public LevelTypes _currentLevelType;
    private LevelData _level;
    public List<Questions> _questionsList = new List<Questions>();
    private List<string> _answerString = new List<string>();
    private int _currentQuestionNo = 1;
    #endregion

    private void Start()
    {
        Instance = this;
    }

    public void GetType(LevelTypes levelType)
    {
        _currentLevelType = levelType;
    }


    public void StartQuiz()
    {
        LoadQuestions();
        GiveQuestion();
    }

    private void LoadQuestions()
    {
        _questionsList.Clear();
        _level = GetLevelData(_currentLevelType);
        foreach (var ques in _level.questions)
        {
            _questionsList.Add(ques);
        }
    }

    private void GiveQuestion()
    {
        string question = _questionsList[_currentQuestionNo-1].questionText;
        List<string> answersArray = GetAnswerOfQuestion(_questionsList[_currentQuestionNo-1]);
        if (_currentQuestionNo < 11)
        {
            GamePlayPanel.Instance.ShowNextQuestion(question, answersArray);
        }
    }

    public void OnAnswerSelected(string selectedAnswer)
    {
        Answers ans = SelectAnswer(selectedAnswer);
        if (ans.isCorrect)
        {
            if(_currentQuestionNo==10)
            {
                AddLogger.DisplayLog("Level Completed");
                OnWrongAnswer();
                return;
            }
            OnCorrectAnswer();
        }
        else
        {
            OnWrongAnswer();
        }
    }

    private void OnCorrectAnswer()
    {
        AddLogger.DisplayLog("question number: " + _currentQuestionNo);
        _currentQuestionNo++;
        GiveQuestion();
    }

    private void OnWrongAnswer()
    {
        UIManager.Instance.TurnOnRetryPanel();
        ResetAllData();
    }

    private void ResetAllData()
    {
        _currentQuestionNo = 0;
        _questionsList.Clear();
        _answerString.Clear();
    }

    private Answers SelectAnswer(string selectedAns)
    {
        foreach (var ans in _questionsList[_currentQuestionNo-1].answers)
        {
            if (selectedAns == ans.answer)
            {
                return ans;
            }
        }
        return null;
    }

    public List<string> GetAnswerOfQuestion(Questions ques)
    {
        _answerString.Clear();
        foreach (var ans in ques.answers)
        {
            _answerString.Add(ans.answer);
        }
        return _answerString;
    }

    private LevelData GetLevelData(LevelTypes levelType)
    {
        foreach (LevelData level in _gameLevelData.levelData)
        {
            if (level.levelType == levelType)
            {
                return level;
            }
        }
        return null;
    }
}
