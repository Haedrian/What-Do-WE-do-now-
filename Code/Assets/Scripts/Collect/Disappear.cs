using UnityEngine;
using System.Collections;

public class Disappear : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.SetActive(false); //Disappear!
    }
}
