using UnityEngine;
using System.Collections;

public class MainMenuKeyboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			Application.LoadLevel(0); //Start the game
		}
	}
}
