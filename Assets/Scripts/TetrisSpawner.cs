using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisSpawner : MonoBehaviour {
    public GameObject[] _tetraminos;
    public float _spawnInterval = 3.5f;

    public int _tetraminoIndex;

    private float _spawnTimer;
    private BoxCollider _spawnBox;

    private void Awake() {
        _spawnBox = GetComponent<BoxCollider>();
    }

    public void Spawn() {
        _spawnTimer = Time.time + _spawnInterval;

        float spawnMin = transform.position.x - (_spawnBox.size.x / 2f);
        float spawnMax = transform.position.x + (_spawnBox.size.x / 2f) + 1f;
        float spawnX = Mathf.Floor(Random.Range(spawnMin, spawnMax));

        Vector3 spawnPos = new Vector3(spawnX, transform.position.y, transform.position.z);

        Instantiate(_tetraminos[_tetraminoIndex], spawnPos, transform.rotation);
        _tetraminoIndex = (_tetraminoIndex + 1) % _tetraminos.Length;
    }

    private void Update() {
        if (Time.time > _spawnTimer)
            Spawn();
    }
}
