using UnityEngine;
using System.Collections;

public class YellowKeyboardController : MonoBehaviour {

	public TimerRun Timer;
	public KeyCode E = KeyCode.E;
	public KeyCode W = KeyCode.W;
	
	public Transform Correct;
	public Transform Incorrect;
    public Transform Base;

	public KeyCode WinKey = KeyCode.E;

	private bool ButtonPressed;

    public AudioSource CorrectSound;
    public AudioSource WrongSound;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool WPressed = false;
		bool EPressed = false;

		CheckKeyPresses (out WPressed, out EPressed);

		if (GetComponent<TimerRun>().InstructionsTimeLeft > 0)
		{
			return;
		}
		
		if (ButtonPressed) 
		{
			return;
		}

		if (WPressed)
		{
			ButtonPressed = true;
			
			if (W == WinKey)
			{
				this.GetComponent<TimerRun>().MissionComplete = true;
				Base.gameObject.SetActive(false);
                Correct.gameObject.SetActive(true);
                CorrectSound.Play();
			}
			else 
			{
                Base.gameObject.SetActive(false);
                Incorrect.gameObject.SetActive(true);
                WrongSound.Play();
			}
		}
		else if (EPressed)
		{
			ButtonPressed = true;
			
			if (E == WinKey)
			{
				this.GetComponent<TimerRun>().MissionComplete = true;
                Base.gameObject.SetActive(false);
                Correct.gameObject.SetActive(true);
                CorrectSound.Play();
			}
			else 
			{
                Base.gameObject.SetActive(false);
                Incorrect.gameObject.SetActive(true);
                WrongSound.Play();
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
