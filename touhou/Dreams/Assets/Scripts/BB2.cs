﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB2 : MonoBehaviour
{
    //public Transform Player;
    //private Transform PPos;
    private float tim;
    public Vector2 dir;


    // Start is called before the first frame update
    void Start()
    {
        tim = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.LookAt(player);
        gameObject.transform.Translate(-Time.deltaTime * Mathf.Pow(2, tim) * 2, 0, 0);
        tim += Time.deltaTime;
    }
}
