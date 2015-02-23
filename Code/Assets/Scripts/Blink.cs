using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    double time = 0f;

	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        if (time > Random.Range(0.25f,0.75f))
        {
            time = 0;

            this.gameObject.GetComponent<SpriteRenderer>().enabled = !this.gameObject.GetComponent<SpriteRenderer>().enabled;
            //Flash
        }

	}
}
