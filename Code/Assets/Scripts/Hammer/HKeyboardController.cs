using UnityEngine;

public class HKeyboardController : MonoBehaviour
{
    private const string HAMMER_NAME = "hammer";

    public KeyCode HammerIn = KeyCode.W, PullUp = KeyCode.E;

    public TimerRun Timer;

    public HWinConditions WinCondition;

    public int MaximumActions = 1;

    private int ActionsTaken = 0;

    private GameObject Hammer = null;

    private bool IsAnimating = false;

    void Start()
    {
        Hammer = GameObject.Find(HAMMER_NAME);
        if (Hammer == null)
            throw new MissingComponentException();
    }

    void Update()
    {
        if (IsAnimating && Hammer.transform.rotation.z <= 0.7f)
        {
            Quaternion newRotation = Hammer.transform.rotation;
            newRotation.z += 2f * Time.deltaTime;

            Hammer.transform.rotation = newRotation;
        }
        else if (Hammer.transform.rotation.z >= 0.4f)
        {
            Quaternion newRotation = Hammer.transform.rotation;
            newRotation.z -= 0.8f * Time.deltaTime;

            Hammer.transform.rotation = newRotation;
        }
        if (Hammer.transform.rotation.z > 0.68f)
            IsAnimating = false;

        if (ActionsTaken >= MaximumActions)
            return;

        if (Timer.InstructionsTimeLeft > 0)
        {
            return;
        }

        if (Input.GetKeyDown(HammerIn))
        {
            ActionsTaken++;

            if (WinCondition == HWinConditions.PullUp)
                Timer.MissionFailed = true;

            IsAnimating = true;
        }
        else if (Input.GetKeyDown(PullUp))
        {
            ActionsTaken++;

            if (WinCondition == HWinConditions.HammerIn)
                Timer.MissionFailed = true;

            //Drop it!
            Hammer.AddComponent<Rigidbody2D>();

            //Quaternion newRotation = Hammer.transform.rotation;
            //newRotation.z = 1f;
            //Hammer.transform.rotation = newRotation;
        }

        if (ActionsTaken == MaximumActions && !Timer.MissionFailed)
            Timer.MissionComplete = true;
    }
}

public enum HWinConditions
{
    HammerIn = 0,
    PullUp = 1
}