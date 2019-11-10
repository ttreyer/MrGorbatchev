using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisSpawner : MonoBehaviour {
    public GameObject[] _tetraminos;
    public float _spawnInterval = 3.5f;

    public int _tetraminoIndex;

    private float _spawnTimer;

    public void Spawn() {
        _spawnTimer = Time.time + _spawnInterval;
        Instantiate(_tetraminos[_tetraminoIndex], transform);
        _tetraminoIndex = (_tetraminoIndex + 1) % _tetraminos.Length;
    }

    private void Update() {
        if (Time.time > _spawnTimer)
            Spawn();
    }
}
