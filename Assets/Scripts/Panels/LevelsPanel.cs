using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class LevelsPanel : MonoBehaviour
{
    #region Variables
    public static LevelsPanel Instance;
    [SerializeField] private List<Button> levelButtons;
    private List<LevelButton> _buttons = new List<LevelButton>();
    private int _unlockedLevels;
    #endregion

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        foreach (Button btn in levelButtons)
        {
            LevelButton lb = btn.GetComponent<LevelButton>();
            if (lb != null) _buttons.Add(lb);
        }
    }

    private void GetUnlockedLevels()
    {
        _unlockedLevels = SaveManager.Instance.GetUnlockedLevels();
    }

    public void SetUnlockLevels()
    {
        GetUnlockedLevels();
        for (int i = 0; i < 10; i++)
        {
            if (i < _unlockedLevels)
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
                _buttons[i].SetupButton();
            }
        }
    }
}
