using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField]
    private float Speed;

    [SerializeField]
    private float JumpSpeed = 15f;

    [SerializeField]
    private LayerMask Ground;

    [SerializeField]
    private Transform ParentTransform;

    [SerializeField]
    private float _gravity = 20f;

    private Rigidbody _rb;
    private Vector3 _velocity;
    private Vector3 _checkPoint;

    private IUIController _uiController;
    private IGameController _gameController;
    private IEnviromentController _enController;

	// Use this for initialization
	void Start () {
        _uiController = GameObject.Find("UI_Manager").GetComponent<IUIController>();
        _gameController = GameObject.Find("Game_Manager").GetComponent<IGameController>();
        _enController = GameObject.Find("Enviroment").GetComponent<IEnviromentController>();

        _rb = GetComponent<Rigidbody>();
        
        if (PlayerPrefs.GetString("Check_Point").Length > 0) {
            _checkPoint = convertToVec3(PlayerPrefs.GetString("Check_Point"));
            this.transform.position = _checkPoint;

            PlayerPrefs.SetString("Check_Point", "");
            PlayerPrefs.Save();
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Physics.Raycast(transform.position, -Vector3.up, 0.7f, Ground)) {
            _velocity = new Vector3(Input.GetAxis("Horizontal") * Speed * Time.fixedDeltaTime, _rb.velocity.y, 0);
            
            if (Input.GetKey(KeyCode.Space)) {
                _velocity.y = JumpSpeed; 
            }
        }

        _velocity.y -= _gravity * Time.fixedDeltaTime;
        _rb.velocity = _velocity;

    }


    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Platform") {
            this.transform.parent = other.collider.transform;

            other.collider.GetComponent<LiftBehaviour>().MOVE = true;
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.collider.tag == "Platform")
            this.transform.parent = ParentTransform;
    }


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Collectable") {
            _uiController.Collectable();
            Destroy(other.gameObject);
        }

        if (other.tag == "Check_Point_One") {
            saveCheckPoint(other);
        }

        if (other.tag == "Check_Point_Two") {
            saveCheckPoint(other);
            _enController.HideLevel(0);
        }

        if (other.tag == "Check_Point_Three") {
            _gameController.EndScene();
        }

        if (other.tag == "Dead_Zone") {
            respawnPlayer();
        }
    }

    private void saveCheckPoint(Collider other) {
        _checkPoint = other.transform.position;
        PlayerPrefs.SetString("Check_Point", _checkPoint.ToString());
        PlayerPrefs.Save();
    }

    private void respawnPlayer() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        destroyPlayer();
    }

    private void destroyPlayer() {
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        Destroy(this.gameObject);
    }

    private Vector3 convertToVec3(string vector) {
        if (vector.StartsWith("(") && vector.EndsWith(")"))
            vector = vector.Substring(1, vector.Length - 2);

        string[] arr = vector.Split(',');

        Vector3 result = new Vector3(
            float.Parse(arr[0]),
            float.Parse(arr[1]),
            float.Parse(arr[2]));

        return result;
    }

    private void OnApplicationQuit() {
        PlayerPrefs.SetString("Check_Point", "");
        PlayerPrefs.Save();
    }
}
