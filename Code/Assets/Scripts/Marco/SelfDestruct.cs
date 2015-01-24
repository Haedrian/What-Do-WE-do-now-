using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public string CollisionTarget = "Player";

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == CollisionTarget)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
}