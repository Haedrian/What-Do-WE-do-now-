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
		else if (Input.GetKeyDown(E))
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
}
