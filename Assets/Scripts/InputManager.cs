using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public FlipperRotator _leftFlipper, _rightFlipper;
    public BallLauncher _ball;
    public TetrisSpawner _tetrisSpawner;

    public float _ballLaunchForce = 2500f;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            _ball.Launch(_ballLaunchForce);
        if (Input.GetKeyDown(KeyCode.Return))
            _tetrisSpawner.Spawn();

        _leftFlipper.FlipToggle(Input.GetKey(KeyCode.LeftArrow));
        _rightFlipper.FlipToggle(Input.GetKey(KeyCode.RightArrow));
    }
}
