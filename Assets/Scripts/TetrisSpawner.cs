using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisSpawner : MonoBehaviour {
    public GameObject[] _tetraminos;
    public float _spawnInterval = 3.5f;

    private float _spawnTimer;
    private BoxCollider _spawnBox;
    private int _lastTetromino;

    private void Awake() {
        _spawnBox = GetComponent<BoxCollider>();
    }

    private GameObject RandomTetromino() {
        // Select a piece different from the last one
        int spawnIndex = _lastTetromino;
        while (spawnIndex == _lastTetromino)
            spawnIndex = Random.Range(0, _tetraminos.Length);
        _lastTetromino = spawnIndex;

        return _tetraminos[spawnIndex];
    }

    private Vector3 RandomPosition() {
        // Select random pos on X-axis, aligned on grid with the Floor()
        float spawnMin = transform.position.x - (_spawnBox.size.x / 2f);
        float spawnMax = transform.position.x + (_spawnBox.size.x / 2f) + 1f;
        float spawnX = Mathf.Floor(Random.Range(spawnMin, spawnMax));

        return new Vector3(spawnX, transform.position.y, transform.position.z);
    }

    private Quaternion RandomRotation() {
        int rotIndex = Random.Range(0, 4);
        float rotDeg = rotIndex * 90f;
        return transform.rotation * Quaternion.Euler(0f, 0f, rotDeg);
    }

    public void Spawn() {
        // Reset timer for next tetramino
        _spawnTimer = Time.time + _spawnInterval;

        // Select a random position
        Vector3 spawnPos = RandomPosition();

        // Select a random rotation
        Quaternion rotation = RandomRotation();

        // Select a random tetromino
        GameObject spawnTetramino = RandomTetromino();

        // Instantiate the new piece
        Instantiate(spawnTetramino, spawnPos, rotation);
    }

    private void Update() {
        if (Time.time > _spawnTimer)
            Spawn();
    }
}
