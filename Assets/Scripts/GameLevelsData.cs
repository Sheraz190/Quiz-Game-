using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public enum LevelTypes
{
    Geography = 0,
    History = 1,
    Cities = 2,
    Sports = 3,
    Culture = 4,
    Current_Affairs = 5,
    LandMarks = 6,
    Personalities = 7,
    Agriculture = 8,
    Cars = 9
}

[Serializable]
public class Questions
{
    public string questionText;
    public List<Answers> answers;
}

[Serializable]
public class Answers
{
    public string answer;
    public bool isCorrect;
}

[Serializable]
public class LevelData
{
    public LevelTypes levelType;
    public List<Questions> questions;
}

[CreateAssetMenu(fileName = "Levels Data", menuName = "Quiz Game/Levels Data")]

public class GameLevelsData : ScriptableObject
{
    public List<LevelData> levelData;
}
