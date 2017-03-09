using UnityEngine;
using System.Collections;

public class MenuUI : MonoBehaviour {

    GameManager _gameManager;

    void Awake()
    {
        _gameManager = GeneralMethods.GetGameManager();
    }

    public void LoadNewGameLevel(string name)
    {
        _gameManager.levelManager.LoadGameLevel(name);
    }

    public void QuitGame()
    {
        _gameManager.QuitGame();
    }
}
