using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSounds : MonoBehaviour {
    public AudioSource _ballHitSource;

    public AudioClip[] _hitSounds;

    private void OnCollisionEnter(Collision collision) {
        if (_ballHitSource.isPlaying)
            return;

        int hitIndex = Random.Range(0, _hitSounds.Length);
        _ballHitSource.pitch = Random.Range(0.8f, 1.5f);
        _ballHitSource.PlayOneShot(_hitSounds[hitIndex]);
    }
}
