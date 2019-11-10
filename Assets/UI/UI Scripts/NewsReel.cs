using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsReel : MonoBehaviour
{
    public string[] headlines;
    [SerializeField] private Text newsText;
    [SerializeField] private string news;
    RectTransform textRextTransform;
    private float charLengthInPx = 43f;
    private float startPos = 660f;
    private Vector2 textStartPosition;
    private float totalAdvanced = 0f;

    [SerializeField] private bool scrollright = false;
    [SerializeField] private bool flash = false;

    // Start is called before the first frame update
    void Start()
    {
        textRextTransform = newsText.GetComponent<RectTransform>();
        news = null;

        UpdateNews("Hello World.", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (scrollright && !flash)
        {
            if (totalAdvanced == 0f)
           {
                StartCoroutine("ScrollFromRight");
           }
        }
        else if (scrollright && flash)
        {
            if (totalAdvanced == 0f)
            {
                StartCoroutine("ScrollFromRightThenFlash");
            }
        }
    }

    //update the score and score display durring gameplay
    public void UpdateNews(string newHeadline, bool scroll)
    {
        scrollright = scroll;
        news = newHeadline;
        newsText.text = news;

        if(scroll)
        {
            textStartPosition = new Vector2(textRextTransform.anchoredPosition.x, -93.8f);

            Debug.Log("Text Start Position is" + textStartPosition.x);
        }
        else
        {
            textStartPosition = new Vector2(textRextTransform.anchoredPosition.x,
                                            textRextTransform.anchoredPosition.y);
        }

    }

    public void UpdateNews(int headlineIndex, bool scroll)
    {
        scrollright = scroll;
        news = headlines[headlineIndex];
        newsText.text = news;

        if (scroll)
        {
            textStartPosition = new Vector2(textRextTransform.anchoredPosition.x, -93.8f);

            Debug.Log("Text Start Position is" + textStartPosition.x);
        }
        else
        {
            textStartPosition = new Vector2(textRextTransform.anchoredPosition.x,
                                            textRextTransform.anchoredPosition.y);
        }

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
            //advance text field by advanceBy in the X
            textRextTransform.anchoredPosition = new Vector3 (textStartPosition.x -totalAdvanced,
                                                                textStartPosition.y
                                                                );
            totalAdvanced += advanceBy;

            Debug.Log("total advanced is " + totalAdvanced);
        }

        totalAdvanced = 0;
        yield break;
    }


    private IEnumerator ScrollFromRightThenFlash()
    {
        totalAdvanced = 1;
        float advanceBy = 5f;
        float textLength = TextLength();

        textRextTransform.anchoredPosition = textStartPosition;

        while (totalAdvanced <= (textLength))
        {
            yield return new WaitForSecondsRealtime(.1f);
            //advance text field by advanceBy in the X
            textRextTransform.anchoredPosition = new Vector3(textStartPosition.x - totalAdvanced,
                                                                textStartPosition.y
                                                                );
            totalAdvanced += advanceBy;

            Debug.Log("total advanced is " + totalAdvanced);
        }

        totalAdvanced = 0;
        yield break;
    }

    private float TextLength()
    {
        int stringLength = news.Length;
        float textLengthInPx = stringLength * charLengthInPx;
        Debug.Log("Text length in Px is " + textLengthInPx);

        return textLengthInPx;
    }
}
