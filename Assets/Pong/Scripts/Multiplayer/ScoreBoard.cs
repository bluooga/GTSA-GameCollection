using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    public GameObject gameManager;

    public int Player1Score;
    public int Player2Score;

    public Text Player1Text;
    public Text Player2Text;


    // Start is called before the first frame update
    void Start()
    {
        Player1Score = 0;
        Player2Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Player1Text.text = Player1Score.ToString();
        Player2Text.text = Player2Score.ToString();

        if (Player1Score == 5 || Player2Score == 5)
        {
                gameManager.GetComponent<PongGameManager>().checkWinner();
        }
    }
}
