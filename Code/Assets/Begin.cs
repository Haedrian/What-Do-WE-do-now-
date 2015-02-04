using UnityEngine;
using System.Collections;

public class Begin : MonoBehaviour {

	// Use this for initialization
	void Awake () 
    {
        Application.LoadLevel("MainMenu");
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
