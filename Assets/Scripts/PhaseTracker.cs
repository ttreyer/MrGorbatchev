using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

[System.Serializable]
public struct PhaseObjects {
    public GameObject[] add;
    public GameObject[] remove;
}

public class PhaseTracker : MonoBehaviour
{
    public int currentPhase = 0;
    public Image bGUIcolorTint;

    public GameObject spawner;
    public HingeJoint bonusFlipper;

    public Vector3 objectOffset;
    public PhaseObjects[] phaseObjects;

    private NewsReel newsReel;

    // Start is called before the first frame update
    void Start()
    {
        newsReel = gameObject.GetComponent<NewsReel>();
        ChangePhase(1);
    }

    public void ChangePhase(int newPhase) {
        currentPhase = newPhase;
        PlayMusic(newPhase);

        PhaseObjects currentObjects = phaseObjects[currentPhase - 1];
        foreach  (var obj in currentObjects.add)
            obj.transform.DOMove(obj.transform.position + objectOffset, 1f);

        foreach (var obj in currentObjects.remove)
            obj.transform.DOMove(obj.transform.position - objectOffset, 1f);

        switch (currentPhase) {
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

    private void Update() {
        newsReel.UpdateNewsContents(currentPhase);
    }

    private void Phase1()
    {
        //set background color
        bGUIcolorTint.color = new Color(0f, 0f, 0f, 0.4f); //translucent black
        //alternately, change the image
        // bGUIcolorTint.sprite = /*whateversprite*/;
    }

    private void Phase2()
    {
        spawner.SetActive(true);

        //set background color
        bGUIcolorTint.color = new Color(1f, 0f, 0f, 0.4f); //translucent red
        //alternately, change the image
        // bGUIcolorTint.sprite = /*whateversprite*/;
    }


    private void Phase3()
    {

        //set background color
        bGUIcolorTint.color = new Color(.8f,0f,1f,0.4f);  //translucent purple
        //alternately, change the image
        // bGUIcolorTint.sprite = /*whateversprite*/;

        bonusFlipper.autoConfigureConnectedAnchor = false;
        bonusFlipper.transform
            .DOMove(bonusFlipper.transform.position + objectOffset, 1f)
            .OnComplete(() => bonusFlipper.autoConfigureConnectedAnchor = true);
    }


    private void Phase4()
    {
        spawner.SetActive(false);
        //set background color
        bGUIcolorTint.color = new Color(0f, 0f, 1f, 0.4f); //translucent blue
        //alternately, change the image
        // bGUIcolorTint.sprite = /*whateversprite*/;
    }

    private void PlayMusic(int musicIndex)
    {
        if (MusicManager.instance)
            MusicManager.instance.PlayMusic(musicIndex);
    }
}
