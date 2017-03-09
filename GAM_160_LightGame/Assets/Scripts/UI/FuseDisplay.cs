using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuseDisplay : MonoBehaviour {

    GameManager _gameManager;

    public Text displayText;

    void Awake()
    {
        _gameManager = GeneralMethods.GetGameManager();
    }

    void Update()
    {
        displayText.text = _gameManager.lightManager.collectedFuses + "/" + _gameManager.lightManager.fuseCount;
    }
}
