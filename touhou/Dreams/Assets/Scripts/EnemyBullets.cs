using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    void Update()
    {
            if (gameObject.transform.position.x >= -10)
            {
                gameObject.transform.Translate(new Vector3(-2f * Time.deltaTime, 0, 0));
            }
            else
            {
                //make a pool of objects set up instead of destroying each object
                Destroy(gameObject);
            }

    }
}
