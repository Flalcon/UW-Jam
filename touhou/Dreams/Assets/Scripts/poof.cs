﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poof : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(stopPoof());
    }

    IEnumerator stopPoof()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
