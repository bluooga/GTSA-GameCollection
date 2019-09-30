using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    //public Scene PongSinglePlayer;
    //public Scene MultiplayerPong;
    public GameObject scoreBoard;
    public GameObject pongOptions;
    public string currentScene;
    

    [SerializeField] public GameObject[] screens;

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void PongStartGame()
    {
        if (pongOptions.GetComponent<PongOptions>().gamemodenumber == 0)
        {
            SceneManager.LoadScene(1);
        }else if(pongOptions.GetComponent<PongOptions>().gamemodenumber == 1)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void PongMultiPlayerRematch()
    {
        scoreBoard.GetComponent<ScoreBoard>().Player1Score = 0;
        scoreBoard.GetComponent<ScoreBoard>().Player2Score = 0;
        Debug.Log("buttonPressed");
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void SPPongRetry()
    {
        Debug.Log("buttonPressed");
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void MainMenuLoad()
    {
        scoreBoard.GetComponent<ScoreBoard>().Player1Score = 0;
        scoreBoard.GetComponent<ScoreBoard>().Player2Score = 0;


        Debug.Log("buttonPressed");
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;

    }
    public void MainMenuLoad2()
    {
        Debug.Log("buttonPressed");
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;

    }
    public void openMainMenuPanel()
    {
        screens[1].SetActive(false);
        screens[2].SetActive(false);
        screens[0].SetActive(true);
    }

    public void OpenGamesPanel()
    {
        screens[2].SetActive(false);
        screens[0].SetActive(false);
        screens[1].SetActive(true);
    }

    public void PongGameOptions()
    {
        screens[0].SetActive(false);
        screens[1].SetActive(false);
        screens[2].SetActive(true);
    }
}
