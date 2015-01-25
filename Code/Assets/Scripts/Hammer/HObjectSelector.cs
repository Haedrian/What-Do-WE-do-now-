using UnityEngine;
using System.Collections;

public class HObjectSelector : MonoBehaviour
{
    public Transform[] PossibleObjects;

    void Start()
    {
        if (PossibleObjects != null && PossibleObjects.Length > 0)
        {
            int selectedIndex = Random.Range(0, PossibleObjects.Length);

            PossibleObjects[selectedIndex].position = this.transform.position;

            HKeyboardController keyController = PossibleObjects[selectedIndex].GetComponent<HKeyboardController>();

            if (keyController == null)
                throw new MissingComponentException();
            else
                keyController.enabled = true;
        }
    }
}