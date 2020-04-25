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
    public Sprite laserEye;

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

            case 2:
                spd = 4f;
                enemyHealth = 200;
                gameObject.GetComponent<SpriteRenderer>().sprite = laserEye;
                break;
                
        }
        bulletspd = 3;
    }

   
    void Update()
    {
        
        switch (type) {
            case 0:
                gameObject.transform.Translate(new Vector3(-spd * Time.deltaTime, 0, 0));
                if (BT <= 0)
                {
                    GameObject B = Instantiate(EB);
                    B.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion());
                    B.GetComponent<EnemyBullets>().dir = new Vector2(bulletspd, type * Random.Range(-bulletspd, bulletspd));
                    BT = 2;
                }
                break;
            case 1:
                gameObject.transform.Translate(new Vector3(-spd * Time.deltaTime, 0, 0));
                if (BT <= 0)
                {
                    GameObject B = Instantiate(EB);
                    B.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion());
                    B.GetComponent<EnemyBullets>().dir = new Vector2(bulletspd, type * Random.Range(-bulletspd, bulletspd));
                    BT = 2;
                }
                break;
            case 2:
                //move to a new position
                //fire laser
                //gameObject.transform.Translate(new Vector3(-spd * Time.deltaTime, 0, 0));
                gameObject.transform.SetPositionAndRotation(Vector2.Lerp(gameObject.transform.position, new Vector2(gameObject.transform.position.x - 5, gameObject.transform.position.y), 1/spd), new Quaternion());

                if (BT <= 0)
                {
                    GameObject B = Instantiate(EB);
                    B.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion());
                    B.GetComponent<EnemyBullets>().dir = new Vector2(bulletspd, type * Random.Range(-bulletspd, bulletspd));
                    BT = 2;
                }
                break;

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
