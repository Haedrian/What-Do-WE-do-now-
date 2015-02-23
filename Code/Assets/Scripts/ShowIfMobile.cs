using UnityEngine;
using System.Collections;

public class ShowIfMobile : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//If it's android, show it.
		#if UNITY_ANDROID
		this.GetComponent<SpriteRenderer>().enabled = true;
			#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
