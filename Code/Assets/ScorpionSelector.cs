using UnityEngine;

public class ScorpionSelector : MonoBehaviour
{
    public Transform LeftEntryPoint, RightEntryPoint;

    private EntryPoints entryPoint;

    public EntryPoints EntryPoint
    {
        get { return entryPoint; }
    }

    void Start()
    {
        bool isLeftEntryPoint = System.Convert.ToBoolean(Random.Range(0, 2));

        if (isLeftEntryPoint)
        {
            Debug.Log("Scorpion will enter from Left...");
            entryPoint = EntryPoints.Left;

            this.transform.position = LeftEntryPoint.position;
        }
        else
        {
            Debug.Log("Scorpion will enter from Right...");
            entryPoint = EntryPoints.Right;

            this.transform.position = RightEntryPoint.position;

            // Flip the scorpion sprite
            Vector3 invertedPosition = this.transform.localScale;
            invertedPosition.x *= -1;
            this.transform.localScale = invertedPosition;
        }
    }

    public enum EntryPoints
    {
        Left = 0,
        Right = 1
    }
}