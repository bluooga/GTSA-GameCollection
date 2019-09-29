using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    public GameObject scoreBoard;
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

    }

    public void PongMultiPlayerRematch()
    {
        scoreBoard.GetComponent<ScoreBoard>().Player1Score = 0;
        scoreBoard.GetComponent<ScoreBoard>().Player2Score = 0;
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log("buttonPressed");
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1f;
    }

    public void SPPongRetry()
    {
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log("buttonPressed");
        SceneManager.LoadScene(currentScene);
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
