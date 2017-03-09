using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager _instance;

    [HideInInspector]
    public LevelManager levelManager;
    public PlayerManager playerManager;
    public EnemyManager enemyManager;
    public CursorManager cursorManager;
    public LightManager lightManager;
    public SoundManager soundManager;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        levelManager = GetComponent<LevelManager>();
        playerManager = GetComponent<PlayerManager>();
        enemyManager = GetComponent<EnemyManager>();
        cursorManager = GetComponent<CursorManager>();
        lightManager = GetComponent<LightManager>();
        soundManager = GetComponent<SoundManager>();
    }

    public void EndGame()
    {
        levelManager.LoadEndScreen();
        playerManager.ChangePlayerState(false);
        cursorManager.UnLockMouse();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
