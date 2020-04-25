using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    public GameObject player;
    public Vector2 dir;

    void Start()
    {

    }

    void Update()
    {
            if (gameObject.transform.position.x >= -10)
            {
                gameObject.transform.Translate(dir * -Time.deltaTime);
            }
            else
            {
                //make a pool of objects set up instead of destroying each object
                Destroy(gameObject);
            }

    }

}
