using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct Row {
    public GameObject[] row;
}

public class MatrixSpawner : MonoBehaviour {
    public float _spawnRate = 3.5f;
    public GameObject _template;
    public Row[] matrix;

    private List<List<GameObject>> _tetrominos;
    private float _spawnTime;
    private SpawnerSpawner _spawner;

    private HashSet<GameObject> _tetrominosInSpawner = new HashSet<GameObject>();

    static readonly System.Random rng = new System.Random();

    public void SetSpawner(SpawnerSpawner spawner) {
        _spawner = spawner;
    }

    private void Awake() {
        int rowIndex = 0;

        _tetrominos = new List<List<GameObject>>(matrix.Length);
        foreach (var row in matrix) {
            _tetrominos.Add(new List<GameObject>(row.row.Length));
            foreach (var tetromino in row.row)
                _tetrominos[rowIndex].Add(tetromino);

            ++rowIndex;
        }

        for (int i = 0; i < _tetrominos.Count; ++i) {
            _tetrominos[i] = _tetrominos[i]
                .OrderBy(r => rng.Next())
                .ToList();
        }

        _spawnTime = Time.time + _spawnRate;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time > _spawnTime) {
            if (_tetrominos.Count == 0)
                SpawnSpawner();
            else
                SpawnTetromino();
        }
    }

    private void SpawnSpawner() {
        if (_tetrominosInSpawner.Count != 0)
            return;

        _spawner.SpawnSpawner();
        Destroy(gameObject);
    }

    private GameObject NextTetrominos() {
        return _tetrominos[0][0];
    }

    private void SpawnTetromino() {
        var T = NextTetrominos();

        T.transform.parent = null;
        T.SetActive(true);
        T.GetComponent<TetrisFall>().SetSpawner(this);
        _tetrominos[0].Remove(T);

        _spawnTime += _spawnRate;

        if (_tetrominos[0].Count == 0)
            _tetrominos.RemoveAt(0);
    }

    private void Print() {
        Debug.Log("--- " + _tetrominosInSpawner.Count);
        for (int i = 0; i < _tetrominos.Count; ++i)
            Debug.Log("Row " + i + ": " + _tetrominos[i].Count + " pieces remaining");
    }

    public void TetrominoDestroyed(GameObject tetromino) {
        _tetrominosInSpawner.Remove(tetromino);
    }

    private void OnTriggerEnter(Collider other) {
        _tetrominosInSpawner.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other) {
        _tetrominosInSpawner.Remove(other.gameObject);
    }
}
