using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public ScoreKeeper instance;
    [SerializeField] private Text scoreText;
    [SerializeField] private int score;

    private NewsReel newsReel;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        newsReel = gameObject.GetComponent<NewsReel>();
    }

    void Update()
    { 
    //ForTesting
        AddToScore(1);

        if(ScoreGreaterThan1mil()) return;
        else if (ScoreGreaterThan100thou()) return;
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


    private bool ScoreGreaterThan1mil()
    {
        if (score >= 1000000)
        {
            newsReel.UpdateNews("Over 1 million! WOW!", false, 0);
            //does other stuff

            return true;
        }
        else
        {
            return false;
        }
    }

    private bool ScoreGreaterThan100thou()
    {
        if (score >= 100000)
        {
            newsReel.UpdateNews("You are pretty good at this.", true, 0);
            return true;
        }
        else
        {
            return false;
        }
    }
}
