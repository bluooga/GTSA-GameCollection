using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongGameManager : MonoBehaviour
{

    public bool isPaused;
    public GameObject pauseScreen;
    public GameObject Scoreboard;
    public GameObject Playerwinner;
    public float currenttimescale;

    public Text PlayerNumber;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            pauseCommand();
        }
    }

    void pauseCommand()
    {

        if (!isPaused)
        {
            currenttimescale = Time.timeScale;
            Time.timeScale = 0.0f;
            pauseScreen.SetActive(true);
            isPaused = true;
        }
        else if (isPaused)
        {
            Time.timeScale = currenttimescale;
            pauseScreen.SetActive(false);
            isPaused = false;
        }
    }

    public void checkWinner()
    {
        if (Scoreboard.GetComponent<ScoreBoard>().Player1Score == 5)
        {
            PlayerNumber.text = "1";
            Playerwinner.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Scoreboard.GetComponent<ScoreBoard>().Player2Score == 5)
        {
            PlayerNumber.text = "2";
            Playerwinner.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
