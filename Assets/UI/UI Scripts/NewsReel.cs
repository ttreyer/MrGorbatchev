using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsReel : MonoBehaviour
{
    public string[] headlines;
    public string[] newsArticle;
    public string[] quotes;
    [SerializeField] private Text headlineText;
    [SerializeField] private Text newsText;
    [SerializeField] private Text quoteText;
    [SerializeField] private string currentHeadline;

    private int fieldLimit = 12; //number of characters that fit in the stationary headline
    RectTransform textRextTransform;
    private float charLengthInPx = 43f;
    private float startPos = 660f;
    private Vector2 textStartPosition;
    private float totalAdvanced = 0f;

    [SerializeField] private bool scrollright = false;

    // Start is called before the first frame update
    void Start()
    {
        textRextTransform = headlineText.GetComponent<RectTransform>();
        currentHeadline = null;

        //for testing
        UpdateNewsContents(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (scrollright)
        {
            if (totalAdvanced == 0f)
           {
                StartCoroutine("ScrollFromRight");
           }
        }
    }

    public void UpdateNewsContents(int phase)
    {
        //Update headline and scroll if long enough
        UpdateHeadline(phase-1);
        //Update news
        UpdateNews(phase-1);
        //update quote and scroll if long enough
        UpdateQuote(phase-1);
    }
    

    private void UpdateHeadline(int headlineIndex)
    {
        currentHeadline = headlines[headlineIndex];
        headlineText.text = currentHeadline;
        scrollright = (currentHeadline.Length > fieldLimit);

        if (scrollright)
        {
            textStartPosition = textRextTransform.anchoredPosition;

        }
        else
        {
            textRextTransform.anchoredPosition = new Vector2(0f, 0f);
        }

    }

    private void UpdateNews(int newsIndex)
    {
        newsText.text = newsArticle[newsIndex];
    }

    
    private void UpdateQuote(int quoteIndex)
    {
        quoteText.text = quotes[quoteIndex];
    }

    private IEnumerator ScrollFromRight()
    {
        totalAdvanced = 1;
        float advanceBy = 5f;
        float textLength = TextLength();

        textRextTransform.anchoredPosition = textStartPosition;

        while (totalAdvanced <= (textLength+startPos))
        {
            yield return new WaitForSecondsRealtime(.1f);
            
            textRextTransform.anchoredPosition = new Vector3 (textStartPosition.x -totalAdvanced,
                                                                textStartPosition.y
                                                                );
            totalAdvanced += advanceBy;
        }

        totalAdvanced = 0;
        yield break;
    }

    private float TextLength()
    {
        int stringLength = currentHeadline.Length;
        float textLengthInPx = stringLength * charLengthInPx;

        return textLengthInPx;
    }
}
