using UnityEngine;
using System.Collections;

public class YellowKeyboardController : MonoBehaviour {

	public TimerRun Timer;
	public KeyCode E = KeyCode.E;
	public KeyCode W = KeyCode.W;
	
	public Transform A;
	public Transform F;

	public KeyCode WinKey = KeyCode.E;

	private bool ButtonPressed;

    public AudioSource Scribble;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GetComponent<TimerRun>().InstructionsTimeLeft > 0)
		{
			return;
		}
		
		if (ButtonPressed) 
		{
			return;
		}

		if (Input.GetKeyDown(W))
		{
            Scribble.Play();

			ButtonPressed = true;
			
			if (W == WinKey)
			{
				this.GetComponent<TimerRun>().MissionComplete = true;
				A.gameObject.SetActive(true);
			}
			else 
			{
                F.gameObject.SetActive(true);
			}
		}
		else if (Input.GetKeyDown(E))
		{
            Scribble.Play();

			ButtonPressed = true;
			
			if (E == WinKey)
			{
				this.GetComponent<TimerRun>().MissionComplete = true;
                A.gameObject.SetActive(true);
			}
			else 
			{
                F.gameObject.SetActive(true);
			}

		}
		
	}
}
