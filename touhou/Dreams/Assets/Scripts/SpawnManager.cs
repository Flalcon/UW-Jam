using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;
    public GameObject enemyObject;
    public float xSpawnPos = 11.0f;
    public float ySpawnRange = 4.5f;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;

            Vector2 spawnPosition = GenerateSpawnPosition();
            GameObject newEnemy = Instantiate(enemyObject, spawnPosition, enemyObject.transform.rotation);
            int type = Mathf.RoundToInt(Random.Range(0,4));
            Debug.Log(type);
            newEnemy.GetComponent<EnemyBehaviour>().type = type;//Implement something so we can set spawn positions later(only do this if we have time)

        }
    }

    Vector2 GenerateSpawnPosition()
    {
        float yPos = Random.Range(-ySpawnRange, ySpawnRange);
        return new Vector2(xSpawnPos, yPos);
    }
}
