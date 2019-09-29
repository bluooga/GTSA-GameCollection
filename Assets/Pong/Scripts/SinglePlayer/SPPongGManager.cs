using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPPongGManager : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseScreen;
    public GameObject GameOver;
    public float currenttimescale;
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
    public void SingleGameEnd()
    {
        GameOver.SetActive(true);
        Time.timeScale = 0f;
    }
}
