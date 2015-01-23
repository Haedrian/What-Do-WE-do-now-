using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadAtRandom : MonoBehaviour {

	/// <summary>
	/// The integers of scene numbers containing game scenes
	/// </summary>
	public List<int> SceneNumbers;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (SceneNumbers.Count  <= 0)
		{
			//Player won!
		}
		else 
		{
			int sceneRandom = SceneNumbers [Random.Range(0,(SceneNumbers.Count))];

			//Remove the scene number from the list
			SceneNumbers.Remove (sceneRandom);

			Application.LoadLevel (sceneRandom);
		}
	}
}
