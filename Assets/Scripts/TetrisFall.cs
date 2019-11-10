using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisFall : MonoBehaviour {
    public float _fallInterval = 1f;
    public Vector3 _fallSpeed = new Vector3(0f, -1f, 0f);

    private Rigidbody _rbody;
    private float _fallTime;
    private bool _mustFreeze;

    private void NewFallTime() {
        _fallTime = Time.time + _fallInterval;
    }

    private void Fall() {
        NewFallTime();

        // Keep the positions rounded
        Vector3 newPosition = _rbody.position + _fallSpeed;
        newPosition.x = Mathf.Round(newPosition.x);
        newPosition.y = Mathf.Round(newPosition.y);
        newPosition.z = Mathf.Round(newPosition.z);

        _rbody.position = newPosition;
    }

    private void Freeze() {
        enabled = false;
    }

    private void Awake() {
        _rbody = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        _rbody.constraints = RigidbodyConstraints.None;
        NewFallTime();
    }

    private void OnDisable() {
        _rbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void FixedUpdate() {
        if (Time.time > _fallTime) {
            if (_mustFreeze) Freeze();
            else Fall();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        _mustFreeze = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("TetrisStop"))
            _mustFreeze = true;
    }
}
