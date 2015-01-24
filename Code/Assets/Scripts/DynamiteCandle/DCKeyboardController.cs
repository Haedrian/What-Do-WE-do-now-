using UnityEngine;

public class DCKeyboardController : MonoBehaviour
{
    public KeyCode Ignite = KeyCode.W, DoNothing = KeyCode.E;

	public TimerRun Timer;

	public AudioSource Explosion;

    /// <summary>
    /// Determines which value of the possible enumeration indicates that the win condition has been reached.
    /// </summary>
    public WinConditions WinCondition;

    /// <summary>
    /// Determines whether a key has been pressed - to prevent further key presses from being processed.
    /// </summary>
    private bool _keyPressed;

	private bool _ignite;

    public enum WinConditions
    {
        DoNothing = 0,
        Ignite = 1
    }

	void Start()
	{
		_ignite = false;
	}

    void Update()
    {
        if (this._keyPressed)
            return;

        if (Input.GetKeyDown(Ignite))
        {
            this._keyPressed = true;

			this._ignite = true;

			if (this.Explosion != null)
			{
				this.Explosion.Play();
			}

            if (WinCondition == WinConditions.Ignite)
            {
				Timer.MissionComplete = true;
            }
        }
        else if (Input.GetKeyDown(DoNothing))
        {
            this._keyPressed = true;

			this._ignite = false;

            if (WinCondition == WinConditions.DoNothing)
            {
				Timer.MissionComplete = true;
            }
        }

        if (this._ignite)
        {
            // Enable any child GameObjects - which will be used to handle animation
            for (int i = 0; i < this.transform.childCount; i++)
                this.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}