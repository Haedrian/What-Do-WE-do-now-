using UnityEngine;
using System.Collections;

public class ScorpionScript : MonoBehaviour {

	/// <summary>
	/// The maximum time in seconds to mvoe
	/// </summary>
	public double MaxTimeSeconds = 4;
	public Vector3 EndLocation;
	private Vector3 StartLocation;

	private double TimeLeft;


	// Use this for initialization
	void Start () 
	{
		TimeLeft = MaxTimeSeconds;
		StartLocation = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		TimeLeft -= Time.deltaTime;

		TimeLeft = TimeLeft < 0 ? 0 : TimeLeft;

		double timeFraction = TimeLeft / MaxTimeSeconds;

		this.transform.position = Vector3.Lerp (EndLocation, StartLocation, (float)timeFraction);
	}
}
