using UnityEngine;

public class DCKeyboardController : MonoBehaviour
{
    public KeyCode Ignite = KeyCode.W, DoNothing = KeyCode.E;

	public TimerRun Timer;

	public AudioSource Explosion;

    public Transform Splint;

    /// <summary>
    /// Determines which value of the possible enumeration indicates that the win condition has been reached.
    /// </summary>
    public WinConditions WinCondition;

    /// <summary>
    /// Determines whether a key has been pressed - to prevent further key presses from being processed.
    /// </summary>
    private bool _keyPressed;

	private bool _ignite;

    public enum WinConditions
    {
        DoNothing = 0,
        Ignite = 1
    }

	void Start()
	{
		_ignite = false;
	}

    void Update()
    {
		bool W = false;
		bool E = false;

		CheckKeyPresses (out W, out E);

		Debug.Log ("W = " + W);

        if (this._keyPressed)
		{
            return;
		}

        if (this.Timer.InstructionsTimeLeft > 0)
        {
            return; //Instructions still showing
        }

        if ((Ignite == KeyCode.W && W) || (Ignite == KeyCode.E && E))
        {
            this._keyPressed = true;

			this._ignite = true;

			if (this.Explosion != null)
			{
				this.Explosion.Play();
			}

            if (WinCondition == WinConditions.Ignite)
            {
				Timer.MissionComplete = true;
            }
        }
        else if ((DoNothing == KeyCode.E && E) || (DoNothing == KeyCode.W && W))
        {
            this._keyPressed = true;

			this._ignite = false;

            if (WinCondition == WinConditions.DoNothing)
            {
				Timer.MissionComplete = true;
            }

            //remove the splint
            Splint.gameObject.SetActive(false);
        }

        if (this._ignite)
        {
            // Enable any child GameObjects - which will be used to handle animation
            for (int i = 0; i < this.transform.childCount; i++)
                this.transform.GetChild(i).gameObject.SetActive(true);
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