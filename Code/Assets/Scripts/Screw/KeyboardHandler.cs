using UnityEngine;
using System.Collections;

public class KeyboardHandler : MonoBehaviour {

	public TimerRun Timer;
	public KeyCode Screw = KeyCode.W;
	public KeyCode DontScrew = KeyCode.E;

	public Transform ScrewItem;
	public Transform ScrewDriver;
	public Transform WoodPlank;
	public Transform Hand;
	public Transform Bang;
	public AudioSource Smack;
    public AudioSource Squeak;

	private bool soundPlayed;

	public bool ScrewPressed = false;
	public bool DontScrewPressed = false;
	
	public KeyCode WinKey = KeyCode.W;
	public KeyCode LoseKey = KeyCode.E;

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
		
		if (ScrewPressed || DontScrewPressed)
		{
			if (ScrewPressed)
			{
				if (ScrewItem != null)
				{
					ScrewItem.Rotate(Vector3.forward,-5);
				}

				ScrewDriver.Rotate(Vector3.up,-5);
			}
			else 
			{
				if (ScrewItem != null)
				{
					ScrewItem.gameObject.SetActive(false);
					Hand.gameObject.SetActive(false);
				}

				ScrewDriver.gameObject.SetActive(false);


				if (WoodPlank != null)
				{
                    Timer.MissionFailed = true; //We failed

					//-0.4
					if (WoodPlank.transform.position.y > -0.4f)
					{
						Vector3 pos = WoodPlank.transform.position;
						pos.y -= 0.1f;
						WoodPlank.transform.position = pos;
					}
					else 
					{
						Bang.gameObject.SetActive(true);

                     

						if (!soundPlayed)
						{
							Smack.time = 0.15f;
							Smack.Play();
                            Squeak.Play();
							soundPlayed = true;
						}
					}
				}
			}
			return;
		}
		
		if (Input.GetKeyDown(Screw))
		{
			ScrewPressed = true;

			if (Screw == WinKey)
			{
				// Signal WON
				Debug.Log("You win...");
				
				this.GetComponent<TimerRun>().MissionComplete = true;
			}
            else
            {
                //You lost, 
                this.GetComponent<TimerRun>().MissionFailed = true;
            }
		}
		
		if (Input.GetKeyDown(DontScrew))
		{
			DontScrewPressed = true;

			
			if (DontScrew == WinKey)
			{
				// Signal WON
				Debug.Log("You win...");
				
				this.GetComponent<TimerRun>().MissionComplete = true;
			}
		}
	}
}
