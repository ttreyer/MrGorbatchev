using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpawner : MonoBehaviour {
    public GameObject[] _matrixSpawners;

    public void SpawnSpawner() {
        int spawnerIndex = Random.Range(0, _matrixSpawners.Length);
        Instantiate(_matrixSpawners[spawnerIndex], transform)
            .GetComponent<MatrixSpawner>()
            .SetSpawner(this);
    }

    private void Start() {
        SpawnSpawner();
    }
}
