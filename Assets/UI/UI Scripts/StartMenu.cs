using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Trying to start music");
        MusicManager.instance.PlayMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
