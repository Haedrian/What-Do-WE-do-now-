using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // Congratulations fly out to Elizabeth Kemp for being the first person to finish the game.

    public TimerRun Timer;

    private bool isDead = false;

    void Start()
    {
        if (Timer == null)
            throw new MissingReferenceException();
    }

    void Update()
    {
        if (!isDead)
        {
            Vector3 newPosition = this.transform.position;
            newPosition.x -= 0.8f * Time.deltaTime;
            this.transform.position = newPosition;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead)
            return;

        if (collision.gameObject.tag == "Player")
            Timer.MissionFailed = true;
        else
        {
            this.isDead = true;

            // Stop zombie sound and play death animation
            this.GetComponent<AudioSource>().enabled = false;
            this.animation.wrapMode = WrapMode.Once;
            this.animation.Play("die");

            this.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            collision.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
    }
}