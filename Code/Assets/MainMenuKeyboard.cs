using UnityEngine;
using System.Collections;

public class MainMenuKeyboard : MonoBehaviour {

    public bool IsLoser = false;

	// Use this for initialization
	void Start () 
    {
	    //Clear the scenes from prefs
        PlayerPrefs.DeleteKey("scenes");
		Screen.SetResolution (1024, 768, true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool W = false;
		bool E = false;

		CheckKeyPresses (out W, out E);

		if (W)
		{
			Application.LoadLevel("LoadLevelScene"); //Start the game
            PlayerPrefs.SetInt("lastScore", 0);
            PlayerPrefs.Save();
		}
        else if (E)
        {
            Application.LoadLevel("Credits"); //Credits
        }

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
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

	void CheckKeyPresses(out bool W, out bool E)
	{
		W = Input.GetKey(KeyCode.W);
		E = Input.GetKey(KeyCode.E);
		
		
		foreach (Touch touch in Input.touches) 
		{
			if ( touch.phase != TouchPhase.Canceled && touch.phase != TouchPhase.Ended)
			{
				var pixelVector = touch.position;
				
				var viewPortClick = Camera.main.ScreenToViewportPoint(pixelVector);
				if (viewPortClick.x < 0.25f)
				{
					W = true;
				}
				else if (viewPortClick.x > 0.75f)
				{
					E = true;
				}
			}
		}
		
	}

}
