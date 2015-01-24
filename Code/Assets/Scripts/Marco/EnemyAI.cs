using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public string CollisionTarget = "Player";

    public bool IsMoving = false;

    void Update()
    {
        if (IsMoving)
        {
            Vector3 newPosition = this.transform.position;
            newPosition.x -= 0.5f * Time.deltaTime;
            this.transform.position = newPosition;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == CollisionTarget)
        {
            Debug.Log("Die player, die!");
            // Notify loss...
        }
    }
}