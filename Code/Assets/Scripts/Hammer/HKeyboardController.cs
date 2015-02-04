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
		bool W = false;
		bool E = false;

		CheckKeyPresses (out W, out E);

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

        if ((HammerIn == KeyCode.W && W) || (HammerIn == KeyCode.E && E))
        {
            ActionsTaken++;

            if (WinCondition == HWinConditions.PullUp)
                Timer.MissionFailed = true;

            IsAnimating = true;
        }
        else if ((PullUp == KeyCode.E && E) || (PullUp == KeyCode.W && W))
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

	void CheckKeyPresses(out bool W, out bool E)
	{
		W = Input.GetKey(KeyCode.W);
		E = Input.GetKey(KeyCode.E);
		
		
		foreach (Touch touch in Input.touches) 
		{
			if ( touch.phase != TouchPhase.Canceled && touch.phase != TouchPhase.Ended)
			{
				var pixelVector = touch.position;
				
				var viewPortClick = Camera.main.ScreenToViewportPoint(pixelVector);
				if (viewPortClick.x < 0.25f)
				{
					W = true;
				}
				else if (viewPortClick.x > 0.75f)
				{
					E = true;
				}
			}
		}
		
	}

}

public enum HWinConditions
{
    HammerIn = 0,
    PullUp = 1
}

