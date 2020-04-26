using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;
    public GameObject enemyObject;
    public GameObject playerObject;
    public float xSpawnPos = 10.0f;
    public float ySpawnRange = 4.5f;
    private int level = 1;
    public int tolevel = 3;
    private int maxlevel;
    private bool spawning = true;
    public GameObject winScreen;
    
    void Start()
    {
        maxlevel = 5;
    }
    
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn && spawning)
        {
            elapsedTime = 0;

            Vector2 spawnPosition = GenerateSpawnPosition();
            GameObject newEnemy = Instantiate(enemyObject, spawnPosition, enemyObject.transform.rotation);
            int type = Mathf.RoundToInt(Random.Range(0,level));
            newEnemy.GetComponent<EnemyBehaviour>().type = type;//Implement something so we can set spawn positions later(only do this if we have time)
            //if (the player has killed x many enemies) {level up, secondsBetweenSpawn gets smaller}
            if (playerObject.GetComponent<PlayerMovement>().score >= tolevel) {
                playerObject.GetComponent<PlayerMovement>().score = 0;
                tolevel += 2;
                level++;
                secondsBetweenSpawn--;
                if (level >= maxlevel) {
                    spawning = false;
                    winScreen.SetActive(true);
                }
            }
               
        }
    }

    Vector2 GenerateSpawnPosition()
    {
        float yPos = Random.Range(-ySpawnRange, ySpawnRange);
        return new Vector2(xSpawnPos, yPos);
    }
}
