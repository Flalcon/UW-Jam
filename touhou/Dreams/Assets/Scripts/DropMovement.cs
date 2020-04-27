using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMovement : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Translate(-3 * Time.deltaTime,0,0);
    }
}
