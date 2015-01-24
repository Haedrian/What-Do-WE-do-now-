using UnityEngine;

public class ParticleSortLayerChanger : MonoBehaviour
{
    void Start()
    {
        this.renderer.sortingLayerName = "Foreground";
        this.renderer.sortingOrder = 2;
    }
}