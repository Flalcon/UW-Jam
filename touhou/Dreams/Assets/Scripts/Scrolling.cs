using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public GameObject BG1, BG1_1, BG2, BG2_1, BG3, BG3_1, BG4, BG4_1, BG5, BG5_1, BG6, BG6_1;
    private float spd;
    void Start()
    {
        spd = 1;
    }
    
    void Update()
    {
        BG1.transform.Translate(-spd * 6f * Time.deltaTime,0,0);
        if(BG1_1.transform.position.x <= 0){
            BG1.transform.SetPositionAndRotation(new Vector3(0,1,0), new Quaternion());
        }

        BG2.transform.Translate(-spd * 5f * Time.deltaTime, 0, 0);
        if (BG2_1.transform.position.x <= 0)
        {
            BG2.transform.SetPositionAndRotation(new Vector3(0, 1, 0), new Quaternion());
        }

        BG3.transform.Translate(-spd * 4f * Time.deltaTime, 0, 0);
        if (BG3_1.transform.position.x <= 0)
        {
            BG3.transform.SetPositionAndRotation(new Vector3(0, 1, 0), new Quaternion());
        }

        BG4.transform.Translate(-spd * 3f * Time.deltaTime, 0, 0);
        if (BG4_1.transform.position.x <= 0)
        {
            BG4.transform.SetPositionAndRotation(new Vector3(0, 1, 0), new Quaternion());
        }

        BG5.transform.Translate(-spd * 2f * Time.deltaTime, 0, 0);
        if (BG5_1.transform.position.x <= 0)
        {
            BG5.transform.SetPositionAndRotation(new Vector3(0, 1, 0), new Quaternion());
        }

        BG6.transform.Translate(-spd * 1f * Time.deltaTime, 0, 0);
        if (BG6_1.transform.position.x <= 0)
        {
            BG6.transform.SetPositionAndRotation(new Vector3(0, 1, 0), new Quaternion());
        }
    }
}
