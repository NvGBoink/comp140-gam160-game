using UnityEngine;
using System.Collections;

public static class GeneralMethods {

    public static GameManager GetGameManager()
    {
        return GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
}
