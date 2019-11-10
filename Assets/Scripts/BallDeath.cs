using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeath : MonoBehaviour {
    public GameObject _deathAnim;

    private BallManager _manager;

    private void Awake() {
        _manager = GameObject.FindGameObjectWithTag("BallManager")
            .GetComponent<BallManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Death"))
            Die();
    }

    public void Die() {
        _manager.BallDied(gameObject);
        GameObject deathAnimInst = Instantiate(_deathAnim, transform.position, Quaternion.identity);
        Destroy(deathAnimInst, 2f);
        Destroy(gameObject);
    }
}
