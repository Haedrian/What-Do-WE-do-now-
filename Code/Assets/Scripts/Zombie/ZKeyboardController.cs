using UnityEngine;

public class ZKeyboardController : MonoBehaviour
{
    public KeyCode Walk = KeyCode.W, TieShoeLaces = KeyCode.E;

    public GameObject Target;
    private BoxCollider2D TargetCollider;
    private Vector2 originalCenter, originalSize;

    private bool IsWalking = false;

    void Start()
    {
        if (Target == null)
            throw new MissingComponentException();

        TargetCollider = Target.GetComponent<BoxCollider2D>();
        if (TargetCollider == null)
            throw new MissingComponentException();
        originalCenter = TargetCollider.center;
        originalSize = TargetCollider.size;

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

        if (Input.GetKeyDown(Walk) && !Input.GetKey(TieShoeLaces))
        {
            Target.animation.Play("walk");
            this.IsWalking = true;
        }
        else if (Input.GetKeyUp(Walk))
        {
            Target.animation.Play("stand");
            this.IsWalking = false;
        }

        if (Input.GetKeyDown(TieShoeLaces) && !Input.GetKey(Walk))
        {
            Target.animation.Play("tie");

            Vector2 newCenter = TargetCollider.center;
            newCenter.y = 309.8044f;
            TargetCollider.center = newCenter;

            Vector2 newSize = TargetCollider.size;
            newSize.y = 646.4517f;
            TargetCollider.size = newSize;

        }
        else if (Input.GetKeyUp(TieShoeLaces))
        {
            Target.animation.Play("stand");
            TargetCollider.center = originalCenter;
            TargetCollider.size = originalSize;
        }
    }
}