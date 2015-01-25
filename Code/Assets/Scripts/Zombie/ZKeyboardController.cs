using UnityEngine;

public class ZKeyboardController : MonoBehaviour
{
    public KeyCode Walk = KeyCode.W, TieShoeLaces = KeyCode.E;

    public GameObject Target;

    private bool IsWalking = false;

    void Start()
    {
        Target.animation.Play("stand");
    }

    void Update()
    {
        if (IsWalking)
        {
            Vector3 newPosition = Target.transform.position;
            newPosition.x += 2 * Time.deltaTime;
            Target.transform.position = newPosition;
        }

        if (Input.GetKeyDown(Walk))
        {
            Target.animation.Play("walk");
            this.IsWalking = true;
        }
        else if (Input.GetKeyUp(Walk))
        {
            Target.animation.Play("stand");
            this.IsWalking = false;
        }

        if (Input.GetKeyDown(TieShoeLaces))
            Target.animation.Play("tie");
        else if (Input.GetKeyUp(TieShoeLaces))
            Target.animation.Play("stand");
    }
}