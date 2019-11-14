using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidBreak : MonoBehaviour {
    public float _bounceDamping = 0.9f;
    public int _scoreIncrease = 100;

    private ScoreKeeper _score;

    private void Awake() {
        _score = GameObject.FindGameObjectWithTag("ScoreKeeper")
            .GetComponent<ScoreKeeper>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Bounce(collision);
            Break();
        }
    }

    private void Bounce(Collision collision) {
        Rigidbody ballRbody = collision.rigidbody;
        ContactPoint contact = collision.GetContact(0);

        Vector3 newVelocity = Vector3.Reflect(collision.relativeVelocity, -contact.normal);
        ballRbody.velocity = _bounceDamping * newVelocity;
    }

    public void Break() {
        _score.AddToScore(_scoreIncrease);
        Destroy(gameObject);
    }
}
