using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseTracker : MonoBehaviour
{
    public int currentPhase = 0;
    public Image bGUIcolorTint;


    private NewsReel newsReel;

    // Start is called before the first frame update
    void Start()
    {
        newsReel = gameObject.GetComponent<NewsReel>();
        currentPhase = 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentPhase)
        {
            case 1:
                Phase1();
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }
    }

    private void Phase1()
    {
        //start music
        PlayMusic(1);

        //set background color
        bGUIcolorTint.color = Color.red;
        //alternately, change the image
        // bGUIcolorTint.sprite = /*whateversprite*/;

        //update news
        newsReel.UpdateNewsContents(currentPhase);
    }

private void PlayMusic(int musicIndex)
    {
        if (MusicManager.instance)
            MusicManager.instance.PlayMusic(musicIndex);
    }
}
