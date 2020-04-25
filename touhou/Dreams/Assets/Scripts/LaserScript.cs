using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float spd;
    void Start()
    {
        spd = 1;
    }
    
    void Update()
    {
        gameObject.transform.localScale = new Vector3(100/spd,spd,1);
        if (spd <= 0.0001) { Destroy(gameObject); }
        spd -= Time.deltaTime;
    }
}
