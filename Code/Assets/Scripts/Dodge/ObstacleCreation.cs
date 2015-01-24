using UnityEngine;
using System.Collections;

public class ObstacleCreation : MonoBehaviour {

    /// <summary>
    /// The Obstacle to Create
    /// </summary>
    public Transform obstaclePrefab;

    public TimerRun controller;

    /// <summary>
    /// How often to spawn
    /// </summary>
    public float spawnRate = 0.25f;

    private float currentSpawnRate;

    private float timer = 0f;

    private float gameTimer = 0;

    public float rotationMax = 0;

    /// <summary>
    /// Whether to generate this on the rightmost edge
    /// </summary>
    public bool maxOnXAxis = false;
    /// <summary>
    /// Whether to generate this on the topmost edge
    /// </summary>
    public bool maxOnYAxis = true;

    // Use this for initialization
    void Start()
    {
        currentSpawnRate = spawnRate;
        timer = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.InstructionsTimeLeft > 0)
        {
            //Do nothing
            return;
        }

        gameTimer += Time.deltaTime;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            //Spawn something
            timer = Random.Range(currentSpawnRate * 0.75f, currentSpawnRate * 1.25f);

            //Create a new obstacle
            var obstacle = Instantiate(obstaclePrefab) as Transform;

            //Assign it a random position, then force it to one of the sides if necessary
            Vector2 randomPoint = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));

            if (maxOnXAxis)
            {
                randomPoint.x = 1f;
            }

            if (maxOnYAxis)
            {
                randomPoint.y = 1f;
            }

            var position = Camera.main.ViewportToWorldPoint(randomPoint);

            position.z = 1;

            obstacle.position = position;

            Rigidbody2D rigid = obstacle.GetComponent<Rigidbody2D>();

            //rigid.gravityScale = Random.Range(0, 2);
            rigid.angularVelocity = Random.Range(0, rotationMax) * 15;
        }

        //Update current spawn rate
        currentSpawnRate = spawnRate - (gameTimer / 35);

        if (currentSpawnRate < 0.05)
        {
            currentSpawnRate = 0.05f;
        }
    }
}
