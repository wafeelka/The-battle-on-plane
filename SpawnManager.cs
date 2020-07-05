using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Prefabs;
    public GameObject powerUpItems;
    public int enemyCount;
    private int howMuchEnemy = 1;
             
    // Start is called before the first frame update
    void Start()
    {
        Spawner(howMuchEnemy); 
        powerUpItemsSpawn();       
    }

    // Update is called once per frame
    void Update()
    {              
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if(enemyCount == 0)
        {
            howMuchEnemy++;
            Spawner(howMuchEnemy);
            powerUpItemsSpawn();
        }
    }

    void Spawner(int EnemysNumber)
    {
        for(int i = 0; i < EnemysNumber; i++)
        {
            Instantiate(Prefabs, GenerateSpawnPosition(), Prefabs.transform.rotation);
            
        }
        
    }
    public Vector3 GenerateSpawnPosition()
    {
        int spawnPos = 9;
        Vector3 spawnLocation = new Vector3(Random.Range(-spawnPos, spawnPos), 0, Random.Range(-spawnPos, spawnPos));
        return spawnLocation;

    }
    void powerUpItemsSpawn()
    {
        Instantiate(powerUpItems, GenerateSpawnPosition(), powerUpItems.transform.rotation);
    } 
            
}
    