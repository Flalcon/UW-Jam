using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;
    public GameObject enemyObject;

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

            Vector2 spawnPosition = new Vector2(0, 0);
            GameObject newEnemy = Instantiate(enemyObject, spawnPosition, enemyObject.transform.rotation);
        }
    }
}
