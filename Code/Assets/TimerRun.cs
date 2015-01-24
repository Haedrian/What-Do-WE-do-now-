using UnityEngine;
using System.Collections;

public class TimerRun : MonoBehaviour {

	public double TimeMaxSeconds = 4;
	public double InstructionsMaxSeconds = 2;

	public Transform InstructionsTransform;
	public AudioSource Sound;

	private double InstructionsTimeLeft;
	private double TimeLeft {get;set;}
	private float MaxScale {get;set;}

	/// <summary>
	/// Whether the player has pressed the right button or not
	/// </summary>
	public bool MissionComplete = false;

	// Use this for initialization
	void Start () 
	{
		TimeLeft = TimeMaxSeconds;
		MaxScale = this.transform.localScale.x;

		InstructionsTimeLeft = InstructionsMaxSeconds;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (InstructionsTimeLeft > 0)
		{
			InstructionsTimeLeft -= Time.deltaTime;
			return;
		}

		//Hide the transform
		InstructionsTransform.gameObject.SetActive (false);

		if (Sound != null && !Sound.isPlaying)
		{
			Sound.Play();
		}
	
		TimeLeft -= Time.deltaTime;

		TimeLeft = TimeLeft < 0 ? 0 : TimeLeft;

		if (TimeMaxSeconds != 0) 
		{
			//Check what %age of time is lost
			double percentage = TimeLeft / TimeMaxSeconds;

			Vector3 temp = this.transform.localScale;
			temp.x = (float) percentage * MaxScale;

			this.transform.localScale = temp;
		}

		if (TimeLeft <= 0)
		{
			//Time's up, Was the player successful?
			if (MissionComplete)
			{
				//Load the next one
				Application.LoadLevel(0);
			}
			else 
			{
				//Failure
				//TODO: Failure
			}
		}
	}
}
