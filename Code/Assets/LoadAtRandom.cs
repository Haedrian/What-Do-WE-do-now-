using UnityEngine;
using System.Collections;

public class LoadAtRandom : MonoBehaviour {

	/// <summary>
	/// The integers of scene numbers containing game scenes
	/// </summary>
	public int[] SceneNumbers;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		int sceneRandom = SceneNumbers [Random.Range(0,(SceneNumbers.Length))];

		Application.LoadLevel (sceneRandom);
	}
}
