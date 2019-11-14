using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperBouncer : MonoBehaviour {
    public float _bumperForce = 40f;
    public int _scoreIncrease = 10;

    private ScoreKeeper _score;

    private void Awake() {
        _score = GameObject.FindGameObjectWithTag("ScoreKeeper")
            .GetComponent<ScoreKeeper>();
    }

    private void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.GetContact(0);
        Rigidbody ballRbody = collision.rigidbody;

        ballRbody.AddForce(-contact.normal * _bumperForce, ForceMode.VelocityChange);
        _score.AddToScore(_scoreIncrease);
    }
}
