using UnityEngine;
using System.Collections;

public class MainMenuKeyboard : MonoBehaviour {

    public bool IsLoser = false;

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
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Application.LoadLevel(14); //Credits
        }
	}

    void OnGUI()
    {
        if (PlayerPrefs.HasKey("lastScore"))
        {
            GUI.color = Color.white;

            var leftStyle = GUI.skin.GetStyle("Label");
            leftStyle.alignment = TextAnchor.MiddleRight;
            leftStyle.fontSize = 55;
            leftStyle.fontStyle = FontStyle.Bold;

            if (IsLoser)
            {
                GUI.Label(new Rect(10, 30, Screen.width - 30, 60), PlayerPrefs.GetInt("lastScore").ToString(), leftStyle);
            }
            else
            {
                GUI.Label(new Rect(10, Screen.height - 50, Screen.width - 10, 60), PlayerPrefs.GetInt("lastScore").ToString(), leftStyle);
            }
        }
    }
}
