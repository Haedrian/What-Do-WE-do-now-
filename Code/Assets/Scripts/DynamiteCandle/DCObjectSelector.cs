using UnityEngine;

public class DCObjectSelector : MonoBehaviour
{
    public Transform[] PossibleObjects;

    void Start()
    {
        if (PossibleObjects != null && PossibleObjects.Length > 0)
        {
            int selectedIndex = Random.Range(0, PossibleObjects.Length);

            PossibleObjects[selectedIndex].position = this.transform.position;

            DCKeyboardController keyController = PossibleObjects[selectedIndex].GetComponent<DCKeyboardController>();

            if (keyController == null)
                throw new MissingComponentException();
            else
                keyController.enabled = true;
        }
    }
}