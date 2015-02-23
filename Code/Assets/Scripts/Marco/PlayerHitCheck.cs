using UnityEngine;

public class PlayerHitCheck : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(collider.gameObject);
        }
    }
}