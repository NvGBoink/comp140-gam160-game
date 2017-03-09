using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

    public GameObject enemyPrefab;
    public string enemySpawnPointTag = "EnemySpawnPoint";

    [HideInInspector]
    public List<GameObject> enemyWorldReferance = new List<GameObject>();
    [HideInInspector]
    public GameObject[] enemySpawnPoints;

    public void GetEnemySpawnPoints()
    {
        enemySpawnPoints = GameObject.FindGameObjectsWithTag(enemySpawnPointTag);
    }

    public void ClearEnemySpawnPoints()
    {
        enemySpawnPoints = new GameObject[0];
    }

    public void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            if (enemySpawnPoints.Length == 0) //Make sure we get the spawn points before trying to spawn an enemy
            {
                GetEnemySpawnPoints();
            }

            if (enemySpawnPoints.Length > 0)
            {
                int rnd = Random.Range(0, enemySpawnPoints.Length);
                Vector3 spawnPos = enemySpawnPoints[rnd].transform.position;
                GameObject clone = Instantiate(enemyPrefab, spawnPos, transform.rotation) as GameObject;
                enemyWorldReferance.Add(clone);
            }
            else
            {
                Debug.Log("No spawn points found, could not spawn an enemy");
            }
        }
        else
        {
            Debug.Log("No enemy prefab was found please make sure one is defined before trying to spawn enemies");
        }
    }

    public void KillEnemy(GameObject enemy)
    {
        enemyWorldReferance.Remove(enemy);
        Destroy(enemy);
    }
}
