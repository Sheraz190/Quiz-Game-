using UnityEngine;
public class AddLogger : MonoBehaviour
{
    public static void DisplayLog(string message)
    {
        Debug.Log(message);
    }

    public static void DisplayErrorLog(string message)
    {
        Debug.LogError(message);
    }
}
