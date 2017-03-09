using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public GameObject playerPrefab;
    public string playerSpawnPointTag = "PlayerSpawnPoint";

    [HideInInspector]
    public GameObject playerWorldReferance;
    [HideInInspector]
    public GameObject[] playerSpawnPoints;

    public void GetPlayerSpawnPoints()
    {
        playerSpawnPoints = GameObject.FindGameObjectsWithTag(playerSpawnPointTag);
    }

    public void ClearPlayerSpawnPoints()
    {
        playerSpawnPoints = new GameObject[0];
    }

    public void SpawnPlayer()
    {
        if (playerPrefab != null)
        {
            if (playerSpawnPoints.Length == 0) //Make sure we get the spawn points before trying to spawn a player
            {
                GetPlayerSpawnPoints();
            }

            if (playerSpawnPoints.Length > 0)
            {
                int rnd = Random.Range(0, playerSpawnPoints.Length);
                Vector3 spawnPos = playerSpawnPoints[rnd].transform.position;
                GameObject clone = Instantiate(playerPrefab, spawnPos, transform.rotation) as GameObject;
                playerWorldReferance = clone;
            }
            else
            {
                Debug.Log("No spawn points found, could not spawn player");
            }
        }
        else
        {
            Debug.Log("No player prefab was found please make sure one is defined before trying to spawn a player");
        }
    }

    public void RespawnPlayer()
    {
        if (playerSpawnPoints.Length == 0) //Make sure we get the spawn points before trying to respawn spawn a player
        {
            GetPlayerSpawnPoints();
        }

        int rnd = Random.Range(0, playerSpawnPoints.Length);
        Vector3 spawnPos = playerSpawnPoints[rnd].transform.position;
        playerWorldReferance.transform.position = spawnPos;
    }

    public void ChangePlayerState(bool newState)
    {
        CharacterMotor cM = playerWorldReferance.GetComponent<CharacterMotor>();
        MouseRotation mR = playerWorldReferance.GetComponent<MouseRotation>();

        if (cM != null)
        {
            cM.canMove = newState;
        }
        else
        {
            Debug.Log("No Character Motor found on the player prefab");
        }

        if (mR != null)
        {
            mR.canMove = newState;
        }
        else
        {
            Debug.Log("No Mouse Rotation found on the player prefab");
        }
    }
}
