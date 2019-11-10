using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapSpeed : MonoBehaviour {
    public float _maxSpeed = 50f;

    private Rigidbody _rbody;

    private void Awake() {
        _rbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if (_rbody.velocity.sqrMagnitude > (_maxSpeed * _maxSpeed))
            _rbody.velocity = _rbody.velocity.normalized * _maxSpeed;
    }
}
