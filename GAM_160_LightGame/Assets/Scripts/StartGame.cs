using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    public int numberOfEnemies = 1;

    GameManager _gameManager;

    void Awake()
    {
        _gameManager = GeneralMethods.GetGameManager();
    }

    void Start()
    {
        _gameManager.levelManager.LoadUI();

        _gameManager.playerManager.ClearPlayerSpawnPoints();
        _gameManager.playerManager.GetPlayerSpawnPoints();
        _gameManager.playerManager.SpawnPlayer();

        _gameManager.enemyManager.ClearEnemySpawnPoints();
        for (int i = 0; i < numberOfEnemies; i++)
        {
            _gameManager.enemyManager.SpawnEnemy();
        }

        _gameManager.cursorManager.LockMouse();
        _gameManager.lightManager.ClearLights();
        _gameManager.lightManager.GetAllLights();
        _gameManager.lightManager.ChangeLightState(false);
        _gameManager.lightManager.GetAllFuses();
    }
}
