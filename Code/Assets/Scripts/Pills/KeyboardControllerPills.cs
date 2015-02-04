using UnityEngine;

[RequireComponent(typeof(TimerRun))]
public class KeyboardControllerPills : MonoBehaviour
{
    public KeyCode GreenKey = KeyCode.E;
    public KeyCode RedKey = KeyCode.W;

	public bool GreenPressed = false;
	public bool RedPressed = false;

	public KeyCode WinKey = KeyCode.W;
	public KeyCode LoseKey = KeyCode.E;

    public Transform Green;
    public Transform Red;

    // Use this for initialization
    void Start()
    {
    
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

		if (RedPressed || GreenPressed)
		{
			return;
		}

		if ((RedKey == KeyCode.W && W) || (RedKey == KeyCode.E && E))
        {
			RedPressed = true;

            Vector3 newScale = this.Red.transform.localScale;

            newScale.x *= 1.50f;
            newScale.y *= 1.50f;

            this.Red.transform.localScale = newScale;


           if (RedKey == WinKey)
            {
                // Signal WON
                Debug.Log("You win...");

				this.GetComponent<TimerRun>().MissionComplete = true;
            }
        }

        if ((GreenKey == KeyCode.W && W) || (GreenKey == KeyCode.E && E))
        {
			GreenPressed = true;

            Vector3 newScale = this.Green.transform.localScale;

            newScale.x *= 1.50f;
            newScale.y *= 1.50f;

            this.Green.transform.localScale = newScale;

            if (GreenKey == WinKey)
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