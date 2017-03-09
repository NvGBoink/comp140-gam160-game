using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadGameLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }

    public void LoadUI()
    {
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }

    public void LoadEndScreen()
    {
        SceneManager.LoadScene("EndScreen", LoadSceneMode.Additive);
    }
}
