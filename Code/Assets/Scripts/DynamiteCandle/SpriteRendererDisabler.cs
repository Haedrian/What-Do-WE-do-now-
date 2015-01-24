using UnityEngine;

public class SpriteRendererDisabler : MonoBehaviour
{
    /// <summary>
    /// Target GameObject whose SpriteRenderer is to be disabled.
    /// </summary>
    public GameObject Target;

    void Start()
    {
        if (Target != null)
        {
            SpriteRenderer renderer = Target.GetComponent<SpriteRenderer>();

            if (renderer == null)
                throw new MissingComponentException();
            else
                renderer.enabled = false;
        }
    }
}