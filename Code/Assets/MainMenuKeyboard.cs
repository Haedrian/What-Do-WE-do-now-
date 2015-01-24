﻿using UnityEngine;
using System.Collections;

public class MainMenuKeyboard : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	    //Clear the scenes from prefs
        PlayerPrefs.DeleteKey("scenes");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			Application.LoadLevel(0); //Start the game
            PlayerPrefs.SetInt("lastScore", 0);
            PlayerPrefs.Save();
		}
	}

    void OnGUI()
    {
        if (PlayerPrefs.HasKey("lastScore"))
        {
            GUI.color = Color.black;

            var leftStyle = GUI.skin.GetStyle("Label");
            leftStyle.alignment = TextAnchor.MiddleLeft;
            leftStyle.fontSize = 60;
            leftStyle.fontStyle = FontStyle.Bold;

            GUI.Label(new Rect(10, Screen.height - 50, Screen.width - 10, 60), "You survived " + PlayerPrefs.GetInt("lastScore").ToString() + " events", leftStyle);
        }
    }
}
