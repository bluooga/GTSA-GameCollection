using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerScore : MonoBehaviour
{
    public GameObject ball;

    public List<int> ReqToMult = new List<int>() { 1, 10, 25, 50 };
    public List<int> multipliers = new List<int>() { 1, 5, 10, 15 }; 

   // SinglePlayerBall spb;

    [SerializeField] [Range(100,1000)] int ScoreToAdd;
    [SerializeField] int ScoreMultiplier;

    public int PlayerScore;

    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //spb = ball.gameObject.GetComponent<SinglePlayerBall>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = PlayerScore.ToString();
    }

    public void addScore()
    {
        PlayerScore += ScoreToAdd * ScoreMultiplier;
        Debug.Log(PlayerScore);
    }

    public void addmultiplier(int hitCount)
    {
        if(hitCount == ReqToMult[0])
        {
            ScoreMultiplier = multipliers[0];
        }else
        if (hitCount == ReqToMult[1])
        {
            ScoreMultiplier = multipliers[1];
        }else
        if (hitCount == ReqToMult[2])
        {
            ScoreMultiplier = multipliers[2];
        }else
        if (hitCount == ReqToMult[3])
        {
            ScoreMultiplier = multipliers[3];
        }
    }
}
