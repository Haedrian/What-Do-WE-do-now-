using UnityEngine;

public class ZKeyboardController : MonoBehaviour
{
    public KeyCode DropLadder = KeyCode.W, TieShoeLaces = KeyCode.E;

    public GameObject Target;
    private BoxCollider2D TargetCollider;
    private Vector2 originalCenter, originalSize;

    private bool IsWalking = true;

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

        if (Input.GetKeyDown(DropLadder))
        {
            GameObject ladder2 = GameObject.Find("Ladder2");

            if (ladder2 != null)
            {
                Rigidbody2D rigidBody = ladder2.GetComponent<Rigidbody2D>();

                if (rigidBody == null)
                    throw new MissingComponentException();

                rigidBody.gravityScale = 1f;
            }
        }

        if (Input.GetKeyDown(TieShoeLaces) && !Input.GetKey(DropLadder))
        {
            Target.animation.Play("tie");
            this.IsWalking = false;

            Vector2 newCenter = TargetCollider.center;
            newCenter.y = 309.8044f;
            TargetCollider.center = newCenter;

            Vector2 newSize = TargetCollider.size;
            newSize.y = 646.4517f;
            TargetCollider.size = newSize;

        }
        else if (Input.GetKeyUp(TieShoeLaces))
        {
            Target.animation.Play("walk");
            this.IsWalking = transform;

            TargetCollider.center = originalCenter;
            TargetCollider.size = originalSize;
        }
    }
}