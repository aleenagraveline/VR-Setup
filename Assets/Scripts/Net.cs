using UnityEngine;
using TMPro;

public class Net : MonoBehaviour
{
    [SerializeField] private GameObject basketball;
    [SerializeField] private Rigidbody basketballRB;
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private GameObject hoop;
    [SerializeField] private TextMeshPro timerText;
    [SerializeField] private TextMeshPro resetText;
    [SerializeField] private TextMeshPro timerLabel;
    private float timer;
    private float resetTimer = 5;
    private int score;
    private float speed;
    private bool gameEnded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        timer = 120.0f;
        speed = 0.005f;
        resetTimer = 5.0f;
        resetText.gameObject.SetActive(false);
        gameEnded = false;
        basketballRB.constraints = RigidbodyConstraints.FreezeAll;
        basketball.transform.position = new Vector3(0.0f, 0.0f, 1.4f);
        basketballRB.constraints = RigidbodyConstraints.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            resetText.SetText("Game Over");
            gameEnded = true;
            hoop.transform.position = new Vector3(0.0f, hoop.transform.position.y, hoop.transform.position.z);
            speed = 0.0f;
            resetText.gameObject.SetActive(true);
            timerText.SetText(resetTimer.ToString("#.00"));
            timerLabel.SetText("Restarting:");
            resetTimer -= Time.deltaTime;
        }
        else
        {
            timer -= Time.deltaTime;
            timerText.SetText(timer.ToString("#.00"));
        }

        if(hoop.transform.position.x + speed >= 2.0f || hoop.transform.position.x + speed <= -2.0f)
        {
            speed = -speed;
        }

        hoop.transform.position = new Vector3(hoop.transform.position.x + speed, hoop.transform.position.y, hoop.transform.position.z);

        if(resetTimer <= 0)
        {
            Start();
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider == basketball.GetComponent<Collider>() && !gameEnded)
        {
            score++;
            scoreText.SetText(score.ToString());
            if (score % 5 == 0)
            {
                speed *= 2;
            }
        }
    }
}
