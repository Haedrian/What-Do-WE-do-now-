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
    public float MaxTimeSeconds = 4;

    private Vector3 StartLocation;
    private ScorpionSelector selector;
    private float TimeLeft;
    private float yMovement;

    // Use this for initialization
    void Start()
    {
        TimeLeft = MaxTimeSeconds;
        StartLocation = this.transform.position;

        yMovement = Random.Range(-1f, 1f);

        selector = this.transform.GetComponent<ScorpionSelector>();
        if (selector == null)
            throw new MissingReferenceException();
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;

        TimeLeft = TimeLeft < 0 ? 0 : TimeLeft;

        float timeFraction = TimeLeft / MaxTimeSeconds;
        Vector3 newPosition = this.transform.position;

        if (selector.EntryPoint == ScorpionSelector.EntryPoints.Left)
            newPosition = Vector3.Lerp(LeftExitPoint.position, StartLocation, timeFraction);
        else if (selector.EntryPoint == ScorpionSelector.EntryPoints.Right)
            newPosition = Vector3.Lerp(RightExitPoint.position, StartLocation, timeFraction);

        // Move in the y-axis
        newPosition.y = Mathf.Lerp(StartLocation.y, StartLocation.y + yMovement, timeFraction);

        this.transform.position = newPosition;
    }
}