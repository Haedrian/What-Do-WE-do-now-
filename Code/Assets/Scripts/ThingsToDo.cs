using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ThingsToDo : MonoBehaviour
{
    private List<string> thingsToDo;
    private double timeLeft = 5;
    private string message = null;

    void Start()
    {
        TextAsset mytxtData = (TextAsset)Resources.Load("stuffyoucando");
        string txt = mytxtData.text;

        txt = txt.Replace("\r", "");

        thingsToDo = txt.Split('\n').ToList();
    }

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

        GUI.Label(new Rect(10, Screen.height / 2 + 50f, Screen.width - 10, 60), message, leftStyle);
    }
}