using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperRotator : MonoBehaviour {
    public float _flipSpeed = 1000f;

    private float _flipTarget;
    private HingeJoint _joint;

    private void Awake() {
        _joint = GetComponent<HingeJoint>();
    }

    private void FixedUpdate() {
        _joint.motor = new JointMotor {
            targetVelocity = _flipTarget,
            force = _joint.motor.force,
        };
    }

    public void FlipToggle(bool onOff = false) {
        _flipTarget = (onOff ? -1f : 1f) * _flipSpeed;
    }
}
