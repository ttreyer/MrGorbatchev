using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisSquisher : MonoBehaviour {
    public float _squishAmount = 0.05f;

    // Squish the shape to be thinner on the X-axis, independently of the rotation
    private void Awake() {
        float rot = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        float rx = Mathf.Abs(Mathf.Cos(rot));
        float ry = Mathf.Abs(Mathf.Sin(rot));

        foreach (var col in GetComponents<BoxCollider>()) {
            col.size = new Vector3(
                col.size.x - rx * _squishAmount,
                col.size.y - ry * _squishAmount,
                col.size.z);
        }
    }
}
