using UnityEngine;

public class LadderController : MonoBehaviour
{

    public double MaxAnimationTime = 5;
    private double AnimationTimeLeft;

    public TimerRun Timer;

    private Vector3 RotationPoint;

    public GameObject Player;

    public AudioSource Clang;

    public bool ShouldRotate = false;

    void Start()
    {
        if (Timer == null)
            throw new MissingReferenceException();

        Timer.MissionComplete = true;

        AnimationTimeLeft = MaxAnimationTime;
        RotationPoint = new Vector3(-3.26f, 3.9f, -1f);
    }

    void Update()
    {
        if (Timer.InstructionsTimeLeft > 0)
        {
            return; // Wait
        }

        AnimationTimeLeft -= Time.deltaTime;

        // 1 second grace period before the animation starts
        if (AnimationTimeLeft > (MaxAnimationTime - 1))
            return;
        if (AnimationTimeLeft <= 0)
            return;

        AnimationTimeLeft = AnimationTimeLeft < 0 ? 0 : AnimationTimeLeft;

        //Get as fraction
        double fraction = Time.deltaTime / MaxAnimationTime;

        if (ShouldRotate)
            this.transform.RotateAround(RotationPoint, Vector3.forward, (float)(-180 * fraction));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (Clang != null)
        {
            if (!Clang.isPlaying)
            {
                Clang.Play();
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            Timer.MissionComplete = false;
            Timer.MissionFailed = true;

            if (Player != null)
            {
                Player.animation.Play("die");

                ZKeyboardController keyController = GameObject.Find("SceneController").GetComponent<ZKeyboardController>();
                keyController.enabled = false;
            }

        }
        else if (collision.gameObject.name == "ZombieHolder")
            this.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }
}