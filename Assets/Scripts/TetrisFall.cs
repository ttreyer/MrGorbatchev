using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollisionBehavior {
    Destroy, Stop,
}

public class TetrisFall : MonoBehaviour {
    public float _fallInterval = 1f;
    public Vector3 _fallSpeed = new Vector3(0f, -1f, 0f);
    public CollisionBehavior _collisionBehavior = CollisionBehavior.Destroy;

    private Rigidbody _rbody;
    private float _fallTime;
    private bool _mustFreeze;

    private MatrixSpawner _spawner;

    public void SetSpawner(MatrixSpawner spawner) {
        _spawner = spawner;
    }

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
        if (_collisionBehavior == CollisionBehavior.Stop)
            enabled = false;
        else
            Destroy(gameObject);
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

    private void OnDestroy() {
        if (_spawner)
            _spawner.TetrominoDestroyed(gameObject);
    }
}
