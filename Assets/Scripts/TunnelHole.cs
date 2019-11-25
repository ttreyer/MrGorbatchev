using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class TunnelHole : MonoBehaviour {
    public Transform _exitPosition;
    public float _exitSpeed;
    public Vector3 _fallOffset = new Vector3(0f, 0f, 2f);

    public float _fallTime = .5f, _moveTime = .5f;

    private void OnTriggerEnter(Collider other) {
        Rigidbody ball = other.attachedRigidbody;

        // Prevent the ball from triggering this at exit
        if (ball.isKinematic)
            return;

        BallEnter(ball);

        DOTween.Sequence()
            .Append(ball.DOMove(ball.position + _fallOffset, _fallTime))
            .Append(ball.DOMove(_exitPosition.position + _fallOffset, _moveTime))
            .Append(ball.DOMove(_exitPosition.position, _fallTime).SetEase(Ease.InExpo))
            .AppendCallback(() => BallExit(ball));
    }

    private void BallEnter(Rigidbody ball) {
        ball.velocity = Vector3.zero;
        ball.interpolation = RigidbodyInterpolation.Extrapolate;
        ball.isKinematic = true;

        foreach (var col in ball.GetComponents<Collider>())
            col.enabled = false;
    }

    private void BallExit(Rigidbody ball) {
        ball.isKinematic = false;
        ball.interpolation = RigidbodyInterpolation.Interpolate;
        ball.velocity = _exitPosition.forward * _exitSpeed;

        foreach (var col in ball.GetComponents<Collider>())
            col.enabled = true;
    }
}
