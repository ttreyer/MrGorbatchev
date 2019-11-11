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

    private void PlayMusic(int musicIndex) {
        if (MusicManager.instance)
            MusicManager.instance.PlayMusic(musicIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        textRextTransform = newsText.GetComponent<RectTransform>();
        news = null;

        UpdateNews("\"The Wall will be standing in 50 and even in 100 years\" - Erich Honecker, January 19th, 1989", true,1);
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

    //update the score and score display durring gameplay
    public void UpdateNews(string newHeadline, bool scroll, int musicIndex)
    {
        scrollright = scroll;
        news = newHeadline;
        newsText.text = news;

        if(scroll)
        {
            textStartPosition = textRextTransform.anchoredPosition;
        }
        else
        {
            textStartPosition = new Vector2(84.67f, 0f);
        }

        PlayMusic(musicIndex);
        textRextTransform.anchoredPosition = textStartPosition;
    }

    public void UpdateNews(int headlineIndex, bool scroll, int musicIndex)
    {
        scrollright = scroll;
        news = headlines[headlineIndex];
        newsText.text = news;

        if (scroll)
        {
            textStartPosition = textRextTransform.anchoredPosition;

        }
        else
        {
            textRextTransform.anchoredPosition = new Vector2(0f, 0f);
        }

        PlayMusic(musicIndex);
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
        int stringLength = news.Length;
        float textLengthInPx = stringLength * charLengthInPx;

        return textLengthInPx;
    }
}
