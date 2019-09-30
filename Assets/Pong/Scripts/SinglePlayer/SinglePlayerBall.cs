using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerBall : MonoBehaviour
{
    //private variables
    Vector3 ballVelocity;
    Rigidbody rbb;
    Renderer rend;
    public GameObject GameManager;
    public GameObject ScoreBoard;
    //public GameObject GameManager;

    public int yVelocityView;
    public int xVelocityView;
    public float ballSpeed;
    public int hitcount;
    [SerializeField] [Range(1, 100)] public float ballBaseSpeed;
    [SerializeField] [Range(0, 1)] public float acceleration;
    [SerializeField] [Range(1, 10)] public float launchTime;


    private void Awake()
    {
        rbb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startTime());
        ballSpeed = PongOptions.bsSpeed;
        acceleration = PongOptions.accel;
    }

    // Update is called once per frame
    void Update()
    {
        rbb.velocity = ballVelocity;
    }
    IEnumerator startTime()
    {
        Debug.Log("coroutine started");

        yield return new WaitForSeconds(launchTime);

        launchBall();

        Debug.Log("corouting ended");
    }

    void launchBall()
    {

        yVelocityView = Random.Range(0, 2);

        switch (yVelocityView)
        {
            case 0:
                ballVelocity.y = -1 * ballSpeed;
                break;
            case 1:
                ballVelocity.y = 1 * ballSpeed;
                break;
        }
        xVelocityView = Random.Range(0, 2);
        switch (xVelocityView)
        {
            case 0:
                ballVelocity.x = -1 * ballSpeed;
                break;
            case 1:
                ballVelocity.x = 1 * ballSpeed;
                break;
        }

    }
    void restartMatch()
    {
        transform.position = Vector3.zero;
        ballVelocity = Vector3.zero;
        StartCoroutine(startTime());

        Debug.Log("restart command has been executed");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TopBarrierCollision
        if (collision.gameObject.CompareTag("TopBarrier"))
        {
            ballVelocity.y = -1 * ballSpeed;
            //ballSpeed += acceleration;
            Time.timeScale += acceleration;
            Debug.Log("hit Top Barrier");
            collision.gameObject.GetComponent<Renderer>().material.color = rend.material.color;
        }
        //BottomBarrierCollision
        if (collision.gameObject.CompareTag("BottomBarrier"))
        {
            ballVelocity.y = 1 * ballSpeed;
            //ballSpeed += acceleration;
            Time.timeScale += acceleration;
            Debug.Log("hit Bottom Barrier");
            collision.gameObject.GetComponent<Renderer>().material.color = rend.material.color;
        }
        //RightBarrierCollision / Goal Right
        if (collision.gameObject.CompareTag("RightBarrier"))
        {
            //ballSpeed = ballBaseSpeed;
            Time.timeScale = 1f;
            Debug.Log("hit Right Barrier");
            GameManager.GetComponent<SPPongGManager>().SingleGameEnd();
        }
        //LeftBarrierCollision / Goal Left
        if (collision.gameObject.CompareTag("LeftBarrier"))
        {
            //ballSpeed = ballBaseSpeed;
            Time.timeScale = 1f;
            Debug.Log("hit Left Barrier");
            GameManager.GetComponent<SPPongGManager>().SingleGameEnd();
        }
        //Player1Collision
        if (collision.gameObject.CompareTag("Player 1"))
        {
            ballVelocity.x = 1 * ballSpeed;
            //ballSpeed += acceleration;
            Time.timeScale += acceleration;
            Debug.Log("hit Player 1");
            hitcount += 1;
            ScoreBoard.GetComponent<SinglePlayerScore>().addmultiplier(hitcount);
            ScoreBoard.GetComponent<SinglePlayerScore>().addScore();
        }
        //Player2Collision
        if (collision.gameObject.CompareTag("Player 2"))
        {
            ballVelocity.x = -1 * ballSpeed;
            //ballSpeed += acceleration;
            Time.timeScale += acceleration;
            Debug.Log("hit Player 2");
            hitcount += 1;
            ScoreBoard.GetComponent<SinglePlayerScore>().addmultiplier(hitcount);
            ScoreBoard.GetComponent<SinglePlayerScore>().addScore();
        }
    }
}
