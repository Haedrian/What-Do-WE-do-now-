using UnityEngine;

public class PoleFlagController : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject timerObject = GameObject.Find("Controller");
            TimerRun timer = timerObject.GetComponent<TimerRun>();
            timer.MissionComplete = true;
        }
    }
}