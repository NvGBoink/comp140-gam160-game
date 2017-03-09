using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightManager : MonoBehaviour {

    GameManager _gameManager;

    public List<Light> worldLights = new List<Light>();
    public string worldLightTag = "WorldLight";
    public string fuseTag = "Fuse";

    [HideInInspector]
    public int fuseCount = 0;
    [HideInInspector]
    public int collectedFuses = 0;

    void Awake()
    {
        _gameManager = GeneralMethods.GetGameManager();
    }

    public void GetAllLights()
    {
        GameObject[] lightObjects = GameObject.FindGameObjectsWithTag(worldLightTag);
        foreach (GameObject g in lightObjects)
        {
            Light light = g.GetComponent<Light>();

            if (light != null)
            {
                worldLights.Add(light);
            }
        }
    }

    public void ClearLights()
    {
        worldLights = new List<Light>();
    }

    public void ChangeLightState(bool isOn)
    {
        foreach (Light l in worldLights)
        {
            l.enabled = isOn;
        }
    }

    public void GetAllFuses()
    {
        GameObject[] fuses = GameObject.FindGameObjectsWithTag(fuseTag);
        fuseCount = fuses.Length;
    }

    public void AddFuse()
    {
        collectedFuses++;
        CheckFuseCount();
    }

    public void CheckFuseCount()
    {
        if (collectedFuses == fuseCount)
        {
            fuseCount = 0; //This stops the method from running more than once
            collectedFuses = 0; //It also makes sure the variables are cleared of if the player starts a new game
            _gameManager.EndGame();
        }
    }
}
