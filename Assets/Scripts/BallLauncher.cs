using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour {
    private Rigidbody _rbody;
    private float _speed;

    private void Awake() {
        _rbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if (_speed > 0f) {
            _rbody.velocity = _speed * Vector3.up;
            _speed = 0f;
        }
    }

    public void Launch(float speed = 2500f) {
        _speed = speed;
    }
}
