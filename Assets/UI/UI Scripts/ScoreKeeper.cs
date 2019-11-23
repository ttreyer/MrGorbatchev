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
        AddToScore(0);
    }

    void Update()
    { 
    //ForTesting
        //AddToScore(1);

        if (myPhaseTracker.currentPhase ==1)
            {if (Phase2Activate()) return;}
        else if(myPhaseTracker.currentPhase ==2)
            {if (Phase3Activate()) return;}
        else if(myPhaseTracker.currentPhase ==3)
            {if(Phase4Activate()) return;}
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


    private bool Phase2Activate()
    {
        if (score >= 100)  //score greater than 1 million
        {
            //update the phase
            myPhaseTracker.ChangePhase(2);
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool Phase3Activate()
    {
        if (score >= 5000) //score greater than 2 million
        {
            //update the phase
            myPhaseTracker.ChangePhase(3);
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool Phase4Activate()
    {
        if (score >= 15000)  //score greater than 5 million
        {
            //update the phase
            myPhaseTracker.ChangePhase(4);
            return true;
        }
        else
        {
            return false;
        }
    }
}
