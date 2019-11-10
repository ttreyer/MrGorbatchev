using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisSpawner : MonoBehaviour {
    public GameObject[] _tetraminos;
    public float _spawnInterval = 3.5f;

    private float _spawnTimer;
    private BoxCollider _spawnBox;

    private void Awake() {
        _spawnBox = GetComponent<BoxCollider>();
    }

    public void Spawn() {
        // Reset timer for next tetramino
        _spawnTimer = Time.time + _spawnInterval;

        // Select random pos on X-axis, aligned on grid with the Floor()
        float spawnMin = transform.position.x - (_spawnBox.size.x / 2f);
        float spawnMax = transform.position.x + (_spawnBox.size.x / 2f) + 1f;
        float spawnX = Mathf.Floor(Random.Range(spawnMin, spawnMax));

        Vector3 spawnPos = new Vector3(spawnX, transform.position.y, transform.position.z);

        // Select the piece randomly
        int spawnIndex = Random.Range(0, _tetraminos.Length);
        GameObject spawnTetramino = _tetraminos[spawnIndex];

        // Instantiate the new piece
        Instantiate(spawnTetramino, spawnPos, transform.rotation);
    }

    private void Update() {
        if (Time.time > _spawnTimer)
            Spawn();
    }
}
