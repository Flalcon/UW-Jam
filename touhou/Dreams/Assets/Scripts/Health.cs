using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image i;
    public Sprite healthSprite1;
    public Sprite healthSprite2;
    public Sprite healthSprite3;
    public Sprite healthSprite4;
    public Sprite healthSprite5;
    public Sprite healthSprite6;
    public Sprite healthSprite7;
    public Sprite healthSprite8;

    public GameObject player;
    private PlayerMovement p;

    Sprite[] spr;

    void Start()
    {
        spr = new Sprite[8];
        p = player.GetComponent<PlayerMovement>();
        spr[0] = healthSprite1;
        spr[1] = healthSprite2;
        spr[2] = healthSprite3;
        spr[3] = healthSprite4;
        spr[4] = healthSprite5;
        spr[5] = healthSprite6;
        spr[6] = healthSprite7;
        spr[7] = healthSprite8;
    }

    // Update is called once per frame
    void Update()
    {   
        i.sprite  = spr[p.playerHealth-1];
    }
}
