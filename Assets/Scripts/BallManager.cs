using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    public GameObject _ballPrefab;
    public LayerMask _ballLayer;
    public Transform _ballSpawn;
    public GameObject _launcherCap;

    private GameObject _ballToLaunch;
    private HashSet<GameObject> _balls = new HashSet<GameObject>();

    public void SpawnBall() {
        if (_ballToLaunch == null)
            _ballToLaunch = Instantiate(_ballPrefab, _ballSpawn);
    }

    public void BallDied(GameObject ball) {
        _balls.Remove(ball);
    }

    public void Launch(float launchForce) {
        if (_ballToLaunch != null)
            _ballToLaunch.GetComponent<BallLauncher>().Launch(launchForce);
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player"))
            return;

        _launcherCap.SetActive(false);
    }

    private void OnTriggerExit(Collider other) {
        if (!other.CompareTag("Player"))
            return;

        _launcherCap.SetActive(true);

        _balls.Add(_ballToLaunch);
        _ballToLaunch = null;
    }
}
