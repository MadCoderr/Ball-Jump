public interface IUIController {
    void Collectable();
    void ShowPuaseMenu();
    void HidePuaseMenu();
}

public interface IGameController {
    void Restart();
    void MainMenu();
    void EndScene();
}

public interface IEnviromentController {
    void HideLevel(int levelIndex);
    void ShowLevel(int levelIndex);
}
