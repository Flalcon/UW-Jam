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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;

            Vector2 spawnPosition = GenerateSpawnPosition();
            GameObject newEnemy = Instantiate(enemyObject, spawnPosition, enemyObject.transform.rotation);
        }
    }

    Vector2 GenerateSpawnPosition()
    {
        float yPos = Random.Range(-ySpawnRange, ySpawnRange);
        return new Vector2(xSpawnPos, yPos);
    }
}
