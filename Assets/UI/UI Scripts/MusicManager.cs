using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField] private AudioClip[] musicClips;
    [SerializeField] private AudioClip[] soundEffects;
    private AudioSource myAudioSource;
    [SerializeField] private bool musicIsPlaying = false;

    [SerializeField] private int currentClip;


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

        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        myAudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //plays a sound effect at specified vector3 location
    public void SpawnSoundEffect(Vector3 location, int clipIndex)
    {
        //check if the clip can exist in the array
        if (clipIndex > soundEffects.Length)
        {
            Debug.Log("Clip " + clipIndex + " does not exist in the soundEffects Array.");
            return;
        }

        AudioClip clip = soundEffects[clipIndex];
        AudioSource.PlayClipAtPoint(clip, location);
    }

    //plays a sound effect from the camera
    public void SpawnSoundEffect(int clipIndex)
    {
        //check if the clip can exist in the array
        if (clipIndex > soundEffects.Length)
        {
            Debug.Log("Clip " + clipIndex + " does not exist in the soundEffects Array.");
            return;
        }

        AudioClip clip = soundEffects[clipIndex];
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    public void PlayMusic(int clipIndex)
    {
        //check if the clip can exist in the array
        if (clipIndex > musicClips.Length)
        { Debug.Log("Clip " + clipIndex + " does not exist in the musicClips Array.");
            return;
        }

        if (currentClip == clipIndex && musicIsPlaying) return;

        else if(musicIsPlaying)
            { StopTheMusic(); }

        //assign and start the new clip
        currentClip = clipIndex;
        myAudioSource.clip = musicClips[currentClip];
        myAudioSource.loop = true;
        myAudioSource.Play();
        musicIsPlaying = true;
    }

    public void StopTheMusic()
    {
        myAudioSource.Stop();
        musicIsPlaying = false;
    }
}
