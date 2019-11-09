using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperRotator : MonoBehaviour {
    [Range(-45f, 45f)]
    public float _rotRest, _rotFlip;
    public float _flipSpeed = 10f;

    private float _rotTarget;
    private Rigidbody _rbody;

    private void Awake() {
        _rotTarget = _rotRest;
        _rbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        float currentRot = _rbody.rotation.eulerAngles.y;
        float updatedRot = Mathf.LerpAngle(currentRot, _rotTarget, Time.fixedDeltaTime * _flipSpeed);

        _rbody.MoveRotation(Quaternion.Euler(0f, updatedRot, 0f));
    }

    public void FlipToggle(bool toggle = false) {
        _rotTarget = toggle ? _rotFlip : _rotRest;
    }
}
