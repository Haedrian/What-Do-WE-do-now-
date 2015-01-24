using UnityEngine;
using System.Collections;

public class AxeAnimation : MonoBehaviour {

	public double MaxAnimationTime = 4;
	private double AnimationTimeLeft;

	private Vector3 RotationPoint;

	// Use this for initialization
	void Start () 
	{
		AnimationTimeLeft = MaxAnimationTime;
		RotationPoint = new Vector3(4.24f,3.31f,-1f);
		RotationPoint.x = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		AnimationTimeLeft -= Time.deltaTime;

		if (AnimationTimeLeft <= 0)
		{
			return;
		}

		AnimationTimeLeft = AnimationTimeLeft < 0 ? 0: AnimationTimeLeft;

		//Get as fraction
		double fraction = Time.deltaTime / MaxAnimationTime;

		this.transform.RotateAround(RotationPoint,Vector3.forward, (float) (-90* fraction));
	}
}
