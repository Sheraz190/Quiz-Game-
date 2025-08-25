using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    #region Variables/ GameObjects

    public static GameManager Instance;

    [SerializeField] private GameLevelsData _gameLevelData;
    private LevelTypes _currentLevelType;
    private LevelData _level;
    public List<Questions> _questionsList = new List<Questions>();
    private List<string> _answerString = new List<string>();
    private int _currentQuestionNo = 1;
    #endregion
    private void Start()
    {
        Instance = this;
    }


    public void StartQuiz()
    {
        LoadQuestions();
        GiveQuestion();
    }

    private void LoadQuestions()
    {
        _currentLevelType = LevelTypes.Agriculture;
        _level = GetLevelData(_currentLevelType);
        foreach (var ques in _level.questions)
        {
            _questionsList.Add(ques);
        }
    }

    private void GiveQuestion()
    {
        string question = _questionsList[_currentQuestionNo].questionText;
        List<string> answersArray = GetAnswerOfQuestion(_questionsList[_currentQuestionNo]);
        if(answersArray==null)
        {
            AddLogger.DisplayLog("answer is ull");
        }
        if (_currentQuestionNo < 10)
        {
            GamePlayPanel.Instance.ShowNextQuestion(question, answersArray);
        }
    }




    public List<string> GetAnswerOfQuestion(Questions ques)
    {
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
