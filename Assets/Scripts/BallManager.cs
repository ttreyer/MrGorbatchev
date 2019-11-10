using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    public GameObject _ballPrefab;
    public LayerMask _ballLayer;
    public Transform _ballSpawn;

    private HashSet<GameObject> _balls;

    private bool SpawnEmpty() {
        return !Physics.CheckSphere(_ballSpawn.position, 1f, _ballLayer);
    }

    public void SpawnBall() {
        if (SpawnEmpty())
            _balls.Add(Instantiate(_ballPrefab, _ballSpawn));
    }
}
