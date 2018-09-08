using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftBehaviour : MonoBehaviour {

    [SerializeField]
    private Transform PointA;

    [SerializeField]
    private Transform PointB;

    [SerializeField]
    [Range (0, 1)]
    private float LerpPerc = 0.5f;

    public bool MOVE = false;

    private float _time = 0;

    private void Start() {
        _time = Time.time;
    }

    // Update is called once per frame
    void Update () {
        if (MOVE) {
            var elapsed = Time.time - _time;
            transform.position = Vector3.Lerp(PointA.position, PointB.position, (Mathf.Sin(LerpPerc * elapsed) + 1.0f) / 2.0f);
        }
            
    }

}
