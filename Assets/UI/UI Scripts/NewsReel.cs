using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsReel : MonoBehaviour
{

    [SerializeField] private Text newsText;
    [SerializeField] private string news;
    // Start is called before the first frame update
    void Start()
    {
        news = null;
    }

    // Update is called once per frame
    void Update()
    {
        //ForTesting
        UpdateNews("Hello World");
    }

    //update the score and score display durring gameplay
    public void UpdateNews(string newHeadline)
    {
        news = newHeadline;
        newsText.text = news;
    }
}
