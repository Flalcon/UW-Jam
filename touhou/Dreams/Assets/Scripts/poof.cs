using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poof : MonoBehaviour
{
    public void PrintEvent(int die)
    {
        if (die == 1)
        {
            Destroy(gameObject);
        }
    }
}
