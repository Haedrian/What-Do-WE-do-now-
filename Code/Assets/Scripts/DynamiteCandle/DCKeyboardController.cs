using UnityEngine;

public class DCKeyboardController : MonoBehaviour
{
    public KeyCode Ignite = KeyCode.W, DoNothing = KeyCode.E;

    /// <summary>
    /// Determines which value of the possible enumeration indicates that the win condition has been reached.
    /// </summary>
    public WinConditions WinCondition;

    /// <summary>
    /// Determines whether a key has been pressed - to prevent further key presses from being processed.
    /// </summary>
    private bool _keyPressed;

    public enum WinConditions
    {
        DoNothing = 0,
        Ignite = 1
    }

    void Update()
    {
        if (this._keyPressed)
            return;

        if (Input.GetKeyDown(Ignite))
        {
            this._keyPressed = true;

            if (WinCondition == WinConditions.Ignite)
            {
                // Notify of win...
            }
        }
        else if (Input.GetKeyDown(DoNothing))
        {
            this._keyPressed = true;

            if (WinCondition == WinConditions.DoNothing)
            {
                // Notify of win...
            }
        }

        if (this._keyPressed)
        {
            // Enable any child GameObjects - which will be used to handle animation
            for (int i = 0; i < this.transform.childCount; i++)
                this.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}