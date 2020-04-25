using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject EB;
    public float BT;

    void Start()
    {
        
    }

   
    void Update()
    {
        //move towards player
        //shoots bullets
        gameObject.transform.Translate(new Vector3(-0.5f * Time.deltaTime,0,0));
        if (BT <= 0) {
            GameObject B = Instantiate(EB);
            B.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion());
            BT = 2;
        }
        BT -= Time.deltaTime;
        }
}
