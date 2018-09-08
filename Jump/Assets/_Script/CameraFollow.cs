using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform TargetFollow;

    [SerializeField]
    private float CamSpeed = 0.5f;

    [SerializeField]
    private Vector3 OffSet;

	
	void LateUpdate () {
        transform.position = Vector3.Lerp(transform.position, TargetFollow.position + OffSet, CamSpeed);
	}
}
