using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBehaviour : MonoBehaviour {

    [SerializeField]
    private float Time = 0.2f;
    
    private Rigidbody _rb;
    private bool _isFalling = false;

	void Start () {
        _rb = GetComponent<Rigidbody>();
	}

    private void FixedUpdate() {

        if (_isFalling)
            _rb.AddForce(0, 100f, 0, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Player")
            StartCoroutine(waitTime());
    }

    private IEnumerator waitTime() {
        yield return new WaitForSeconds(Time);
        _rb.useGravity = true;
        _isFalling = true;
    }
}
