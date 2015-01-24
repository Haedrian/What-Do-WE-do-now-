using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class LoadAtRandom : MonoBehaviour {

	/// <summary>
	/// The integers of scene numbers containing game scenes
	/// </summary>
	public List<int> SceneNumbers;

	// Use this for initialization
	void Awake () 
	{
		//If playerprefs has the scene numbers, read from there
        if (PlayerPrefs.HasKey("scenes"))
        {
            //It's a comma delimited set of ids
            SceneNumbers = PlayerPrefs.GetString("scenes").Split(',').Select(s => Int32.Parse(s)).ToList();
        }

		if (SceneNumbers.Count <= 0)
		{
			//Player won!
            Application.LoadLevel(9);
		}
		else
		{
			int sceneRandom = SceneNumbers[UnityEngine.Random.Range(0, (SceneNumbers.Count))];
			
			//Remove the scene number from the list
			SceneNumbers.Remove(sceneRandom);

            //Write them to prefs

            PlayerPrefs.SetString("scenes", String.Join(",",SceneNumbers.Select(s => s.ToString()).ToArray()));

            PlayerPrefs.Save();

			Application.LoadLevel(sceneRandom);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
