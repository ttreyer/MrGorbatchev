using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour {
    public float _gravityMultiplier = 1f;

    private Rigidbody _rbody;

    private void Awake() {
        _rbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        _rbody.AddForce(Physics.gravity * _rbody.mass * (_gravityMultiplier - 1f));
    }
}
