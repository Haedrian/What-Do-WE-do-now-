using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ThingsToDo : MonoBehaviour {

    private List<string> thingsToDo;

	// Use this for initialization
	void Start () 
    {
        TextAsset mytxtData = (TextAsset)Resources.Load("stuffyoucando");
        string txt = mytxtData.text;

        txt = txt.Replace("\r", "");

        thingsToDo = txt.Split('\n').ToList();
	}
	
	// Update is called once per frame
	void Update () 
    {
      
	}

    private double timeLeft = 5;
    private string message = null;

    void OnGUI()
    {
        GUI.color = Color.gray;

        var leftStyle = GUI.skin.GetStyle("Label");
        leftStyle.alignment = TextAnchor.MiddleCenter;
        leftStyle.fontSize = 55;
        leftStyle.fontStyle = FontStyle.Bold;

        timeLeft -= Time.deltaTime;

        if (message == null || timeLeft <= 0)
        {
            timeLeft = 5;
            message = thingsToDo[Random.Range(0, thingsToDo.Count)];
        }

        GUI.Label(new Rect(10, Screen.height/2  + 50f, Screen.width - 10, 60), message  , leftStyle);
    }
}
