using UnityEngine;
using System.Collections;

public class DontDestroyScript : MonoBehaviour {

	private static DontDestroyScript instance = null;
	public static  DontDestroyScript Instance
	{
		get { return instance; }
	}
	
	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
		{
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	void onDestroy()
	{
		//Log it
		Debug.Log("I was killed :(");
	}
}
