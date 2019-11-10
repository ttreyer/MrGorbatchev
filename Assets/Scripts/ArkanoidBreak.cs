using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidBreak : MonoBehaviour {
    public float _bounceDamping = 0.9f;

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
        Destroy(gameObject);
    }
}
