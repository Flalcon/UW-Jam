using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int bossHealth = 2000;
    public float speed = 2.0f;
    public GameObject EB, BEB;
    public float bulletspd = 3.0f;
    public GameObject focalPoint;
    private float bulletTimer1;
    private float bigBulletTimer;
    private bool isInvuln = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > 6.35)
        {
            gameObject.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        } 
        else
        {
            isInvuln = false;

            if (bossHealth >= 1000)
            {
                fireBullets1();
            } 
            
            else if (bossHealth < 1000 && bossHealth > 0)
            {
                fireBullets2();
            } 
            
            else if (bossHealth <= 0)
            {
                var player = FindObjectOfType<PlayerMovement>();
                player.score += 50;
                Destroy(gameObject);
            }

            bulletTimer1 -= Time.deltaTime;
            bigBulletTimer -= Time.deltaTime;
        }
    }

    private void fireBullets1()
    {
        if (bulletTimer1 <= 0)
        {
            GameObject newBullet = Instantiate(EB);
            newBullet.transform.SetPositionAndRotation(focalPoint.gameObject.transform.position, new Quaternion());
            newBullet.GetComponent<EnemyBullets>().dir = new Vector2(bulletspd, Random.Range(-bulletspd, bulletspd));

            bulletTimer1 = 0.075f;
        }
    }

    private void fireBullets2()
    {
        if (bigBulletTimer <= 0)
        {
            Vector2 BigBulletDirection = new Vector2(bulletspd, Random.Range(-bulletspd * 0.4f, bulletspd * 0.4f));

            GameObject BigBullet1 = Instantiate(BEB);
            BigBullet1.transform.SetPositionAndRotation(focalPoint.gameObject.transform.position, new Quaternion());
            BigBullet1.GetComponent<BB2>().dir = BigBulletDirection;

            /*
            GameObject BigBullet2 = Instantiate(BEB);
            BigBullet2.transform.SetPositionAndRotation(focalPoint.gameObject.transform.position, new Quaternion());
            BigBullet2.GetComponent<BB2>().dir = BigBulletDirection * new Vector2(1, -1);
            */

            bigBulletTimer = 1.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player Bullet") && isInvuln == false)
        {
            Destroy(collision.gameObject);
            bossHealth -= 20;
        }
    }
}
