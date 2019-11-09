using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{

    [SerializeField] private Text scoreText;
    [SerializeField] private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ForTesting
        //AddToScore(1);
    }

    //update the score and score display durring gameplay
    public void AddToScore (int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    //return current score for display 
    public int GetCurrentScore ()
    {
        return score;
    }
}
