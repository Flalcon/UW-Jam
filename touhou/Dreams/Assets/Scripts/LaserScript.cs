using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float spd;
    public float xpos, ypos;

    void Start()
    {
        xpos = gameObject.transform.position.x;
        ypos = gameObject.transform.position.y;
        spd = 1;
    }
    
    void Update()
    {
        gameObject.transform.localScale = new Vector3(50/spd,spd,1);
        gameObject.transform.SetPositionAndRotation(new Vector3(xpos - 2/spd, ypos, 0), new Quaternion());
        if (spd <= 0.0001) { Destroy(gameObject);}
        spd -= Time.deltaTime;
    }
}
