using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class TunnelHole : MonoBehaviour {
    public Transform _exitPosition;
    public float _exitSpeed;
    public Vector3 _fallOffset = new Vector3(0f, 0f, 2f);

    private void OnTriggerEnter(Collider other) {
        Rigidbody ball = other.attachedRigidbody;

        // Prevent the ball from triggering this at exit
        if (ball.isKinematic)
            return;

        ball.isKinematic = true;

        DOTween.Sequence()
            .Append(ball.DOMove(ball.position + _fallOffset, 1f))
            .Append(ball.DOMove(_exitPosition.position + _fallOffset, 1f))
            .Append(ball.DOMove(_exitPosition.position, 1f).SetEase(Ease.InExpo))
            .AppendCallback(() => BallExit(ball));
    }

    private void BallExit(Rigidbody ball) {
        ball.isKinematic = false;
        ball.velocity = _exitPosition.forward * _exitSpeed;
    }
}
