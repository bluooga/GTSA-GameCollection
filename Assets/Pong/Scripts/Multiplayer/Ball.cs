using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //private variables
    Vector3 ballVelocity;
    Rigidbody rbb;
    Renderer Rend;
    public GameObject ScoreBoard;
    public GameObject TopBorder;
    public GameObject BottomBorder;
    //public GameObject GameManager;


    Color P1Blue = Color.blue;
    Color P2Red = Color.red;

    public int yVelocityView;
    public int xVelocityView;
    public float ballSpeed;
    [SerializeField] [Range(1, 100)] public float ballBaseSpeed;
    [SerializeField] [Range(0,1)]public float acceleration;
    [SerializeField] [Range(1, 10)] public float launchTime;


    private void Awake()
    {
        Rend = GetComponent<Renderer>();
        rbb = GetComponent<Rigidbody>();
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
            TopBorder.GetComponent<Renderer>().material.color = Rend.material.color;
        }
        //BottomBarrierCollision
        if (collision.gameObject.CompareTag("BottomBarrier"))
        {
            ballVelocity.y = 1 * ballSpeed;
            //ballSpeed += acceleration;
            Time.timeScale += acceleration;
            Debug.Log("hit Bottom Barrier");
            BottomBorder.GetComponent<Renderer>().material.color = Rend.material.color;
        }
        //RightBarrierCollision / Goal Right
        if (collision.gameObject.CompareTag("RightBarrier"))
        {
            ScoreBoard.GetComponent<ScoreBoard>().Player1Score += 1;
            restartMatch();
            //ballSpeed = ballBaseSpeed;
            Time.timeScale = 1f;
            Debug.Log("hit Right Barrier");
        }
        //LeftBarrierCollision / Goal Left
        if (collision.gameObject.CompareTag("LeftBarrier"))
        {
            ScoreBoard.GetComponent<ScoreBoard>().Player2Score += 1;
            restartMatch();
            //ballSpeed = ballBaseSpeed;
            Time.timeScale = 1f;
            Debug.Log("hit Left Barrier");
        }
        //Player1Collision
        if (collision.gameObject.CompareTag("Player 1"))
        {
            ballVelocity.x = 1 * ballSpeed;
            //ballSpeed += acceleration;
            Time.timeScale += acceleration;
            Debug.Log("hit Player 1");
            Rend.material.color = P1Blue;
        }
        //Player2Collision
        if (collision.gameObject.CompareTag("Player 2"))
        {
            ballVelocity.x = -1 * ballSpeed;
            //ballSpeed += acceleration;
            Time.timeScale += acceleration;
            Debug.Log("hit Player 2");
            Rend.material.color = P2Red;
        }
    }
}
