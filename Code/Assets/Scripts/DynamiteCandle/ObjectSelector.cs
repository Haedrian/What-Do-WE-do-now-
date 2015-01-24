using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public Transform[] PossibleObjects;

    void Start()
    {
        if (PossibleObjects != null && PossibleObjects.Length > 0)
        {
            int selectedIndex = Random.Range(0, PossibleObjects.Length);
            PossibleObjects[selectedIndex].position = this.transform.position;
        }
    }
}