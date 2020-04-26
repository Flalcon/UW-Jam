using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    public GameObject Source;
    public float rate, tim;
    private Vector3 pos;

    void Start()
    {
        //rate = 0.02f;
        //tim = 0.1f;
        pos = Source.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (tim <= 0) {
            gameObject.transform.SetPositionAndRotation(pos, new Quaternion());
            pos = Source.transform.position;
            tim = rate;
        }
        tim -= Time.deltaTime;
    }
}
