using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanStopZone : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        TetrisFall tetromino = other.GetComponent<TetrisFall>();
        if (tetromino != null)
            tetromino._collisionBehavior = CollisionBehavior.Stop;
    }
}
