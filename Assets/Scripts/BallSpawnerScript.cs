using UnityEngine;

public class BallSpawnerScript : MonoBehaviour
{
    public GameObject ball;
    float spawnFreq = 3;
    float spawnCountdown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCountdown = spawnFreq;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCountdown <= 0)
        {
            GameObject newBall = Instantiate(ball);
            newBall.transform.position = transform.position;
            spawnCountdown = spawnFreq;
        }
        spawnCountdown -= Time.deltaTime;
    }
}

