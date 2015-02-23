using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public string CollisionTarget = "Player";

    public bool IsMoving = false;

    public bool IsInvincible = false;

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
            GameObject timerObject = GameObject.Find("Controller");
            if (timerObject == null)
                throw new MissingReferenceException();

            TimerRun timer = timerObject.GetComponent<TimerRun>();
            if (timer == null)
                throw new MissingComponentException();

            if (IsInvincible)
            {
                timer.MissionComplete = false;
                timer.MissionFailed = true;
            }
            else
            {
                //        float yVelocity = collision.gameObject.transform.rigidbody2D.velocity.y;

                //        if (yVelocity < 0)
                //        {
                //            Debug.Log("Enemy will lose..." + yVelocity);

                //            Destroy(this.gameObject);
                //        }
                //        else
                //        {
                timer.MissionComplete = false;
                timer.MissionFailed = true;
                //        }
            }
        }
    }
}