using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public LevelTypes levelType;

    public void OnLevelSelected()
    {
        GameManager.Instance.GetType(levelType);
    }
}
