using UnityEngine;

public class LadderController : MonoBehaviour
{

    public double MaxAnimationTime = 5;
    private double AnimationTimeLeft;

    public TimerRun Timer;

    private Vector3 RotationPoint;

    void Start()
    {
        if (Timer == null)
            throw new MissingReferenceException();

        AnimationTimeLeft = MaxAnimationTime;
        RotationPoint = new Vector3(-3.26f, 3.9f, -1f);
    }

    void Update()
    {
        AnimationTimeLeft -= Time.deltaTime;

        // 1 second grace period before the animation starts
        if (AnimationTimeLeft > (MaxAnimationTime - 1))
            return;
        if (AnimationTimeLeft <= 0)
            return;

        AnimationTimeLeft = AnimationTimeLeft < 0 ? 0 : AnimationTimeLeft;

        //Get as fraction
        double fraction = Time.deltaTime / MaxAnimationTime;

        this.transform.RotateAround(RotationPoint, Vector3.forward, (float)(-180 * fraction));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Timer.MissionFailed = true;
    }
}