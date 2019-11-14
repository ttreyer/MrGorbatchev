using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public ScoreKeeper instance;
    [SerializeField] private Text scoreText;
    [SerializeField] private int score;

    private PhaseTracker myPhaseTracker;

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
        myPhaseTracker = gameObject.GetComponent<PhaseTracker>();
    }

    void Update()
    { 
    //ForTesting
        //AddToScore(1);

        if(ScoreGreaterThan2mil()) return;
        else if (ScoreGreaterThan1mil()) return;
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
            //update the phase
            myPhaseTracker.currentPhase = 1;
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool ScoreGreaterThan2mil()
    {
        if (score >= 2000000)
        {
            //update the phase
            myPhaseTracker.currentPhase = 2;
            return true;
        }
        else
        {
            return false;
        }
    }
}
