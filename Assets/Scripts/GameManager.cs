using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    #region Variables/ GameObjects
    public static GameManager Instance;
    [SerializeField] private GameLevelsData gameLevelData;
    public List<Questions> questionList = new List<Questions>();
    private List<string> answerString = new List<string>();
    public LevelTypes currentLevelType;
    private LevelData _level;
    private List<Questions> _tempQuestions = new List<Questions>();
    private int _currentQuestionNo = 1;
    private int _currentLevelNumber;
    private int _correctAnswers;
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void GetType(LevelTypes levelType)
    {
        currentLevelType = levelType;
    }

    public void GetCurrentLevelNumber(int num)
    {
        _currentLevelNumber = num;
    }

    public void StartQuiz()
    {
        ResetAllData();
        LoadQuestions();
        GiveQuestion();
    }

    private void LoadQuestions()
    {
        questionList.Clear();
        _tempQuestions.Clear();
        _level = GetLevelData(currentLevelType);
        foreach (var ques in _level.questions)
        {
            questionList.Add(ques);
            _tempQuestions.Add(ques);
        }
    }

    private void GiveQuestion()
    {
        if (_currentQuestionNo < 11)
        {
            string question = questionList[_currentQuestionNo - 1].questionText;
            List<string> answersArray = GetAnswerOfQuestion(questionList[_currentQuestionNo - 1]);
            GamePlayPanel.Instance.ShowNextQuestion(question, answersArray, _currentQuestionNo);
        }
    }

    public void OnAnswerSelected(string selectedAnswer)
    {
        Answers ans = SelectAnswer(selectedAnswer);
        if (ans.isCorrect)
        {
            if (_currentQuestionNo == 10)
            {
                OnLevelCompleted();
                return;
            }
            OnCorrectAnswer();
        }
        else
        {
            if (_currentQuestionNo == 10)
            {
                OnLevelCompleted();
                return;
            }
            OnWrongAnswer();
        }
        GamePlayPanel.Instance.TurnNextButtonOff();
    }

    private void OnNextLevel()
    {
        ResetAllData();
        GetNextLevelType();
    }

    private void GetNextLevelType()
    {
        for (int i = 0; i < gameLevelData.levelData.Count; i++)
        {
            if (currentLevelType == gameLevelData.levelData[i].levelType)
            {
                currentLevelType = gameLevelData.levelData[i + 1].levelType;
                return;
            }
        }
    }

    private void OnLevelCompleted()
    {
        if (_correctAnswers < 6)
        {
            UIManager.Instance.TurnOnRetryPanel();
            return;
        }
        _currentLevelNumber++;
        if (_currentLevelNumber > 10)
        {
            AddLogger.DisplayLog("Level Ends Game finish");
            UIManager.Instance.OnGameComplete();
            return;
        }
        SaveManager.Instance.SetUnlockedLevel(_currentLevelNumber);
        UIManager.Instance.OnLevelCompletedScreen();
        OnNextLevel();
    }

    private void OnCorrectAnswer()
    {
        GamePlayPanel.Instance.MoveCheckBox(true);
        StartCoroutine(CorrectAnswerTimer());
    }

    private IEnumerator CorrectAnswerTimer()
    {
        yield return new WaitForSeconds(1.0f);
        _currentQuestionNo++;
        GiveQuestion();
        _correctAnswers++;
        GamePlayPanel.Instance.ResetCheckBox();
    }

    private void OnWrongAnswer()
    {
        GamePlayPanel.Instance.MoveCheckBox(false);
        StartCoroutine(WrongAnswerTimer());
    }

    private IEnumerator WrongAnswerTimer()
    {
        yield return new WaitForSeconds(1.0f);
        _currentQuestionNo++;
        GiveQuestion();
        GamePlayPanel.Instance.ResetCheckBox();
    }
    private void ResetAllData()
    {
        _currentQuestionNo = 1;
        questionList.Clear();
        answerString.Clear();
        _correctAnswers = 0;
    }

    public void RetryGame()
    {
        StartQuiz();
    }

    private Answers SelectAnswer(string selectedAns)
    {
        foreach (var ans in questionList[_currentQuestionNo - 1].answers)
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
        answerString.Clear();
        foreach (var ans in ques.answers)
        {
            answerString.Add(ans.answer);
        }
        return answerString;
    }

    private LevelData GetLevelData(LevelTypes levelType)
    {
        foreach (LevelData level in gameLevelData.levelData)
        {
            if (level.levelType == levelType)
            {
                return level;
            }
        }
        return null;
    }
}
