using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FlipperEvent : UnityEvent<bool> {}

public class InputManager : MonoBehaviour {
    public FlipperEvent _leftFlippers, _rightFlippers;
    public TetrisSpawner _tetrisSpawner;
    public BallManager _ballManager;

    public float _ballLaunchForce = 2500f;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            _ballManager.Launch(_ballLaunchForce);
        if (Input.GetKeyDown(KeyCode.Return))
            _tetrisSpawner.Spawn();
        if (Input.GetKeyDown(KeyCode.Tab))
            _ballManager.SpawnBall();

        _leftFlippers.Invoke(Input.GetKey(KeyCode.LeftArrow));
        _rightFlippers.Invoke(Input.GetKey(KeyCode.RightArrow));
    }
}
