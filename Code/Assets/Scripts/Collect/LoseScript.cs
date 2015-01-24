using UnityEngine;
using System.Collections;

public class LoseScript : MonoBehaviour {

    public TimerRun controller;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //You lose!
        controller.MissionComplete = false;
    }
}
