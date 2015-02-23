using UnityEngine;

[RequireComponent(typeof(TimerRun))]
public class KeyboardController : MonoBehaviour
{
    public KeyCode LeftLegKey = KeyCode.E;
    public KeyCode RightLegKey = KeyCode.W;

    private bool LeftLegPressed = false;
    private bool RightLegPressed = false;

	public KeyCode WinKey;
	public KeyCode LoseKey;

    public Transform leftLeg;
    public Transform rightLeg;

    private Vector3 leftLegStart;
    private Vector3 rightLegStart;

    public float HeightYCoordinate;

    private float animationTime;
    private float maxAnimationTime = 0.25f;

    private ScorpionSelector selector;

    // Use this for initialization
    void Start()
    {
        leftLegStart = leftLeg.position;
        rightLegStart = rightLeg.position;
        animationTime = maxAnimationTime;
    }

    // Update is called once per frame
    void Update()
    {
		bool W = false;
		bool E = false;

		CheckKeyPresses (out W, out E);

		if (GetComponent<TimerRun>().InstructionsTimeLeft > 0)
		{
			return;
		}

        if (LeftLegPressed || RightLegPressed)
        {
            //If you already raised a leg, just animate it
            animationTime -= Time.deltaTime;

            float animationFraction = animationTime / maxAnimationTime;

            if (LeftLegPressed)
            {
                Vector3 endPosition = leftLegStart;
                endPosition.y = HeightYCoordinate;

                leftLeg.position = Vector3.Lerp(endPosition, leftLegStart, animationFraction);
            }
            else if (RightLegPressed)
            {
                Vector3 endPosition = rightLegStart;
                endPosition.y = HeightYCoordinate;

                rightLeg.position = Vector3.Lerp(endPosition, rightLegStart, animationFraction);
            }

            return;
        }

        if ((LeftLegKey == KeyCode.W && W) || (LeftLegKey == KeyCode.E && E))
        {
            LeftLegPressed = true;

            if (LeftLegKey == WinKey)
            {
                // Signal WON
                Debug.Log("You win...");

				this.GetComponent<TimerRun>().MissionComplete = true;
            }
        }

        if ((RightLegKey == KeyCode.W && W) || (RightLegKey == KeyCode.E && E))
        {
            RightLegPressed = true;

            if (RightLegKey == WinKey)
            {
                // Signal WON
                Debug.Log("You win...");

				this.GetComponent<TimerRun>().MissionComplete = true;
			}
        }
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