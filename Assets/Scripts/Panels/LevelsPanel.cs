using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class LevelsPanel : MonoBehaviour
{
    #region Variables/Game Objects
    public static LevelsPanel Instance;
    [SerializeField] private List<Button> _levelButtons;
    [SerializeField] private List<Image> _buttonImages;
    private int _unlockedLevels;
    #endregion

    private void Awake()
    {
        Instance = this;
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
                _levelButtons[i].interactable = true;
                _buttonImages[i].fillCenter = false;
            }
            else
            {
                _levelButtons[i].interactable = false;
            }
        }
    }
}
