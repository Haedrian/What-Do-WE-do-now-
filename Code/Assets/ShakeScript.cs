using UnityEngine;
using System.Collections;

public class ShakeScript : MonoBehaviour {

	Vector3 originPosition;
	
	float shake_decay;
	float shake_intensity;

	void Start ()
	{
		InvokeRepeating("Shake", 0.5f, 0.5f);
	}

	void Update(){
		if(shake_intensity > 0){
			transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
			shake_intensity -= shake_decay;
		}
	}
	
	void Shake(){
		originPosition = transform.position;
		shake_intensity = .193f;
		shake_decay = 0.02f;
	}
}
