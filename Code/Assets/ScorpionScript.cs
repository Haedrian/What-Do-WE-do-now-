using UnityEngine;

[RequireComponent(typeof(ScorpionSelector))]
public class ScorpionScript : MonoBehaviour
{
    /// <summary>
    /// The possible exit points for the scorpion. The scorpion will move according to the ScorpionSelector's decision.
    /// </summary>
    public Transform LeftExitPoint, RightExitPoint;

    /// <summary>
    /// The maximum time in seconds to move
    /// </summary>
    public double MaxTimeSeconds = 4;

    private Vector3 StartLocation;
    private ScorpionSelector selector;
    private double TimeLeft;


    // Use this for initialization
    void Start()
    {
        TimeLeft = MaxTimeSeconds;
        StartLocation = this.transform.position;

        selector = this.transform.GetComponent<ScorpionSelector>();
        if (selector == null)
            throw new MissingReferenceException();
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;

        TimeLeft = TimeLeft < 0 ? 0 : TimeLeft;

        double timeFraction = TimeLeft / MaxTimeSeconds;

        if (selector.EntryPoint == ScorpionSelector.EntryPoints.Left)
            this.transform.position = Vector3.Lerp(LeftExitPoint.position, StartLocation, (float)timeFraction);
        else if (selector.EntryPoint == ScorpionSelector.EntryPoints.Right)
            this.transform.position = Vector3.Lerp(RightExitPoint.position, StartLocation, (float)timeFraction);
    }
}