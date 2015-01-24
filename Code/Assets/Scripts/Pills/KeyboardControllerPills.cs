using UnityEngine;

[RequireComponent(typeof(TimerRun))]
public class KeyboardControllerPills : MonoBehaviour
{
    public KeyCode GreenKey = KeyCode.E;
    public KeyCode RedKey = KeyCode.W;

	public bool GreenPressed = false;
	public bool RedPressed = false;

	public KeyCode WinKey = KeyCode.W;
	public KeyCode LoseKey = KeyCode.E;

    public Transform Green;
    public Transform Red;

    // Use this for initialization
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
		if (GetComponent<TimerRun>().InstructionsTimeLeft > 0)
		{
			return;
		}

		if (RedPressed || GreenPressed)
		{
			return;
		}

		if (Input.GetKeyDown(RedKey))
        {
			RedPressed = true;
			//Animate it
			Red.GetComponent<ShakeScript>().enabled = true;

           if (RedKey == WinKey)
            {
                // Signal WON
                Debug.Log("You win...");

				this.GetComponent<TimerRun>().MissionComplete = true;
            }
        }

        if (Input.GetKeyDown(GreenKey))
        {
			GreenPressed = true;

			Green.GetComponent<ShakeScript>().enabled = true;

            if (GreenKey == WinKey)
            {
                // Signal WON
                Debug.Log("You win...");

				this.GetComponent<TimerRun>().MissionComplete = true;
			}
        }
    }
}