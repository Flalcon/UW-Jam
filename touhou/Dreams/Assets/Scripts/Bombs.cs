using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bombs : MonoBehaviour
{
    public Image i;
    public Sprite bombSprite0;
    public Sprite bombSprite1;
    public Sprite bombSprite2;

    public GameObject player;
    private PlayerMovement p;

    Sprite[] spr;

    void Start()
    {
        spr = new Sprite[3];
        p = player.GetComponent<PlayerMovement>();
        spr[0] = bombSprite0;
        spr[1] = bombSprite1;
        spr[2] = bombSprite2;
    }

    // Update is called once per frame
    void Update()
    {
        if (p.playerHealth > 0)
            i.sprite = spr[p.bombCount];
        else { Destroy(gameObject); }
    }


}
