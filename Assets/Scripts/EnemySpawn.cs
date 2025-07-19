using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy();

    }

 
    public void spawnEnemy()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, transform.rotation);
    }
    
}
