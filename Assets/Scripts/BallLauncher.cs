using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour {
    private Rigidbody _rbody;
    public float _force;

    private void Awake() {
        _rbody = GetComponent<Rigidbody>();
    }

    void Launch(float force) {
        _force = force;
    }

    private void FixedUpdate() {
        _rbody.AddForce(transform.parent.forward * _force);
        _force = 0f;
    }
}
