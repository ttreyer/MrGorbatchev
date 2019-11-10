using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisSpawner : MonoBehaviour {
    public GameObject[] _tetraminos;

    public int _tetraminoIndex;

    public void Spawn() {
        Instantiate(_tetraminos[_tetraminoIndex], transform);
        _tetraminoIndex = (_tetraminoIndex + 1) % _tetraminos.Length;
    }
}
