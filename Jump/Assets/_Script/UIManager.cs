using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IUIController {

    [SerializeField]
    private Text Score;

    [SerializeField]
    private Canvas PauseMenu;

    private int count = 0;

    public void Collectable() {
        count++;
        Score.text = count.ToString();
    }

    public void HidePuaseMenu() {
        PauseMenu.gameObject.SetActive(false);
    }

    public void ShowPuaseMenu() {
        PauseMenu.gameObject.SetActive(true);
    }
}
