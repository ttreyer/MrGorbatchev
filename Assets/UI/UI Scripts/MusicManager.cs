using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MusicStage {
    public AudioClip _intro, _loop;
    public float _offset;
}

public class MusicManager : MonoBehaviour {
    public static MusicManager instance;

    public MusicStage[] musicClips;
    public AudioClip[] soundEffects;
    private AudioSource myAudioSource;
    public bool musicIsPlaying = false;

    public int currentClip = 0;


    private void Awake() {

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        myAudioSource = gameObject.GetComponent<AudioSource>();
    }

    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    //plays a sound effect at specified vector3 location
    public void SpawnSoundEffect(Vector3 location, int clipIndex) {
        //check if the clip can exist in the array
        if (clipIndex > soundEffects.Length) {
            Debug.Log("Clip " + clipIndex + " does not exist in the soundEffects Array.");
            return;
        }

        AudioClip clip = soundEffects[clipIndex];
        AudioSource.PlayClipAtPoint(clip, location);
    }

    //plays a sound effect from the camera
    public void SpawnSoundEffect(int clipIndex) {
        //check if the clip can exist in the array
        if (clipIndex > soundEffects.Length) {
            Debug.Log("Clip " + clipIndex + " does not exist in the soundEffects Array.");
            return;
        }

        AudioClip clip = soundEffects[clipIndex];
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    public void PlayMusic(int clipIndex) {
        //check if the clip can exist in the array
        if (clipIndex > musicClips.Length) {
            Debug.Log("Clip " + clipIndex + " does not exist in the musicClips Array.");
            return;
        }

        if (currentClip == clipIndex && musicIsPlaying) return;

        else if (musicIsPlaying) { StopTheMusic(); }

        //assign and start the new clip
        MusicStage stage = musicClips[currentClip];

        currentClip = clipIndex;
        myAudioSource.clip = stage._loop;
        myAudioSource.loop = true;
        myAudioSource.PlayOneShot(stage._intro);
        myAudioSource.PlayDelayed(stage._intro.length + stage._offset);
        musicIsPlaying = true;
    }

    public void StopTheMusic() {
        myAudioSource.Stop();
        musicIsPlaying = false;
    }
}
