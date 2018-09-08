using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentBehaviour : MonoBehaviour, IEnviromentController {

    [SerializeField]
    private GameObject[] Levels;

    public void HideLevel(int levelIndex) {
        Levels[levelIndex].SetActive(false);
    }

    public void ShowLevel(int levelIndex) {
        Levels[levelIndex].SetActive(true);
    }
}
