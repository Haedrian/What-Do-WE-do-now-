using UnityEngine;

public class Begin : MonoBehaviour
{
    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        Application.LoadLevel("MainMenu");
    }
}