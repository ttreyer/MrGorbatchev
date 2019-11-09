using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour {
    private Rigidbody _rbody;
    private float _force;

    private void Awake() {
        _rbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        _rbody.AddForce(transform.parent.forward * _force);
        _force = 0f;
    }

    public void Launch(float force = 2500f) {
        _force = force;
    }
}
