using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int bossHealth = 1000;
    public float speed = 2.0f;
    public GameObject EB;
    public float bulletspd = 3.0f;

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
        } else
        {
            fireBullets1();

            Debug.Log("good to go");
        }
    }

    private void fireBullets1()
    {
        GameObject B = Instantiate(EB);
        B.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion());
        B.GetComponent<EnemyBullets>().dir = new Vector2(bulletspd, Random.Range(-bulletspd, bulletspd));
    }
}
