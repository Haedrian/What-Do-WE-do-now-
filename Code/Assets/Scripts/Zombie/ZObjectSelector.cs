using UnityEngine;

public class ZObjectSelector : MonoBehaviour
{
    public bool IsZombieScene;

    void Start()
    {
        IsZombieScene = System.Convert.ToBoolean(Random.Range(0, 2));
        Debug.Log("Is Zombie Scene? " + IsZombieScene);

        GameObject zombie = GameObject.Find("Zombie");

        if (this.IsZombieScene)
        {
            zombie.GetComponent<SkinnedMeshRenderer>().enabled = true;
            zombie.GetComponent<AudioSource>().enabled = true;
            zombie.GetComponent<ZombieController>().enabled = true;
            zombie.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}