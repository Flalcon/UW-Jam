using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject EB;
    public float BT;
    public int enemyHealth;
    public int type;
    public float spd;
    public float bulletspd;


    void Start()
    {
        //there are 2 types of enemy movement: straightforward and LERP
        //Lerp Enemies take longer to fire, but have more powerful attacks & more health
        //straightforward enemies have simpler attacks but start firing asap
        switch (type)
        {
            case 0:
                spd = 0.5f;
                enemyHealth = 60;
                break;
            case 1:
                spd = 2f;
                enemyHealth = 40;
                break;
                
        }
        bulletspd = 3;
    }

   
    void Update()
    {
        //move towards player
        //shoots bullets
        if (type < 2)
        {
            gameObject.transform.Translate(new Vector3(-spd * Time.deltaTime, 0, 0));
            if (BT <= 0)
            {
                GameObject B = Instantiate(EB);
                B.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion());
                B.GetComponent<EnemyBullets>().dir = new Vector2(bulletspd, type * Random.Range(-bulletspd, bulletspd));
                BT = 2;
            }
        }
        else {
            //Fancy Movement
            //Fancy whatever




        }
        
        
        

        BT -= Time.deltaTime;

        if (enemyHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player Bullet"))
        {
            Destroy(collision.gameObject);
            enemyHealth -= 20;
        }
    }
}
