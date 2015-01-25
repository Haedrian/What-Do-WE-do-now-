using UnityEngine;

public class ZObjectSelector : MonoBehaviour
{
    public bool IsZombieScene;

    void Start()
    {
        IsZombieScene = System.Convert.ToBoolean(Random.Range(0, 2));
        Debug.Log("Is Zombie Scene? " + IsZombieScene);

        GameObject ladder = GameObject.Find("Ladder");

        if (this.IsZombieScene)
        {
        }
        else
        {
            LadderController ladderController = ladder.GetComponent<LadderController>();

            if (ladderController == null)
                throw new MissingComponentException();

            ladderController.enabled = true;
        }
    }
}