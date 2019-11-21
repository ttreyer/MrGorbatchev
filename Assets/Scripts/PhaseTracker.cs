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
                Phase2();
                break;
            case 3:
                Phase3();
                break;
            case 4:
                Phase4();
                break;
            default:
                Phase1();
                break;
        }
    }

    private void Phase1()
    {
        //start music
        PlayMusic(1);

        //set background color
        bGUIcolorTint.color = new Color(0f, 0f, 0f, 0.4f); //translucent black
        //alternately, change the image
        // bGUIcolorTint.sprite = /*whateversprite*/;

        //update news
        newsReel.UpdateNewsContents(currentPhase);
    }

    private void Phase2()
    {
        //start music
        PlayMusic(2);

        //set background color
        bGUIcolorTint.color = new Color(1f, 0f, 0f, 0.4f); //translucent red
        //alternately, change the image
        // bGUIcolorTint.sprite = /*whateversprite*/;

        //update news
        newsReel.UpdateNewsContents(currentPhase);
    }


    private void Phase3()
    {
        //start music
        PlayMusic(3);

        //set background color
        bGUIcolorTint.color = new Color(.8f,0f,1f,0.4f);  //translucent purple
        //alternately, change the image
        // bGUIcolorTint.sprite = /*whateversprite*/;

        //update news
        newsReel.UpdateNewsContents(currentPhase);
    }


    private void Phase4()
    {
        //start music
        PlayMusic(4);

        //set background color
        bGUIcolorTint.color = new Color(0f, 0f, 1f, 0.4f); //translucent blue
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
