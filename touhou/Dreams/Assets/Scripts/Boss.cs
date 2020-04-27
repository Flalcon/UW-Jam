﻿using System.Collections;
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
    private float bulletTimer2;
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
            bulletTimer2 -= Time.deltaTime;
        }
    }

    private void fireBullets1()
    {
        if (bulletTimer1 <= 0)
        {
            GameObject B = Instantiate(EB);
            B.transform.SetPositionAndRotation(focalPoint.gameObject.transform.position, new Quaternion());
            B.GetComponent<EnemyBullets>().dir = new Vector2(bulletspd, Random.Range(-bulletspd, bulletspd));

            bulletTimer1 = 0.075f;
        }
    }

    private void fireBullets2()
    {
        if (bulletTimer2 <= 0)
        {
            GameObject B = Instantiate(EB);
            B.transform.SetPositionAndRotation(focalPoint.gameObject.transform.position, new Quaternion());
            B.GetComponent<EnemyBullets>().dir = new Vector2(bulletspd, Random.Range(-bulletspd, bulletspd));

            bulletTimer2 = 0.3f;

            GameObject BB = Instantiate(BEB);
            BB.transform.SetPositionAndRotation(focalPoint.gameObject.transform.position, new Quaternion());
            BB.GetComponent<BB2>().dir = new Vector2(bulletspd, Random.Range(-bulletspd, bulletspd));

            bigBulletTimer = 2.0f;
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