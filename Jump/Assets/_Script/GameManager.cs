using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IGameController {

    private IEnviromentController _enController;

    private void Start() {
        if (GameObject.Find("Enviroment") != null)
            _enController = GameObject.Find("Enviroment").GetComponent<IEnviromentController>();
    }

    public void StartGame() {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void Restart() {
        refreshScenes();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() {
        refreshScenes();
        SceneManager.LoadScene("Main_Menu");
    }

    private void refreshScenes() {
        if (_enController != null) {
            for (int i = 0; i < 2; i++)
                _enController.ShowLevel(i);
            PlayerPrefs.SetString("Check_Point", "");
            PlayerPrefs.Save();
        }
    }

    public void EndScene()  {
        SceneManager.LoadScene("End_Scene");
    }
}
