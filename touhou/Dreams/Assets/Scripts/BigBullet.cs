using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    public Transform Player;
    //private Transform PPos;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.LookAt(player);
        gameObject.transform.Translate(Time.deltaTime * Mathf.Sign(Player.position.x - gameObject.transform.position.x), Time.deltaTime * Mathf.Sign(Player.position.y - gameObject.transform.position.y), 0);
    }
}
