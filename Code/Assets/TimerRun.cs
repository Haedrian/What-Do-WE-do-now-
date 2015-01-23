using UnityEngine;
using System.Collections;

public class TimerRun : MonoBehaviour {

	public double TimeMaxSeconds = 4;
	private double TimeLeft {get;set;}
	private float MaxScale {get;set;}


	// Use this for initialization
	void Start () 
	{
		TimeLeft = TimeMaxSeconds;
		MaxScale = this.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
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
	}
}
