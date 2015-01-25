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
            float yVelocity = collision.gameObject.transform.rigidbody2D.velocity.y;

            if (yVelocity < 0)
            {
                Debug.Log("Enemy will lose..." + yVelocity);

                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Player will lose..." + yVelocity);

                TimerRun timer = GameObject.Find("Controller").GetComponent<TimerRun>();
                if (timer != null)
                    timer.MissionFailed = true;
            }
        }
    }
}