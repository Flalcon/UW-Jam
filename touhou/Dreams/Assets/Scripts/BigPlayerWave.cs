using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPlayerWave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= 15)
        {
            gameObject.transform.Translate(new Vector3(10f * Time.deltaTime, 0, 0));
        }
        else
        {
            //make a pool of objects set up instead of destroying each object
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("big player wave used");
        } else
        {
            Destroy(collision.gameObject);
        }
    }
}
