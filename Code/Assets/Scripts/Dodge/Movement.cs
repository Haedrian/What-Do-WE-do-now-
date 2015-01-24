using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public Vector2 speed = new Vector2(0, 0);
    public TimerRun controller;

    private Vector2 movement;

    public static int ACC = 2;
    public static int MAXSPEED = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //have we moved ?
        //tell the animator
        GetComponent<Animator>().SetBool("IsWalkingLeft", Input.GetKey(KeyCode.W));
        GetComponent<Animator>().SetBool("IsWalkingRight", Input.GetKey(KeyCode.E));

        if (Input.GetKey(KeyCode.W))
        {
            //Flip!
            if (this.transform.localScale.x > 0)
            {
                var ls = this.transform.localScale;
                ls.x *= -1;

                this.transform.localScale = ls;
            }
        }
        else
        if (Input.GetKey(KeyCode.E))
        {
            //Flip!
            if (this.transform.localScale.x < 0)
            {
                var ls = this.transform.localScale;
                ls.x *= -1;

                this.transform.localScale = ls;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            speed.x += -2;

        }
        else if (speed.x < 2)
        {
            speed.x = 0;
        }

        if (Input.GetKey(KeyCode.E))
        {
            speed.x += 2;
        }
        else if (speed.x > 2)
        {
            speed.x = 0;
        }

        if (speed.x > MAXSPEED)
        {
            speed.x = MAXSPEED;
        }
        else if (speed.x < -MAXSPEED)
        {
            speed.x = -MAXSPEED;
        }

        movement = new Vector2(speed.x, speed.y);

        // 6 - Make sure we are not outside the camera bounds
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //You lose!
        controller.MissionComplete = false;
        controller.MissionFailed = true;
    }

    void FixedUpdate()
    {
        // 5 - Move the game object
        rigidbody2D.velocity = movement;
    }
}
