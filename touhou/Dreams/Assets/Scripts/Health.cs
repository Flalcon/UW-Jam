using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Sprite healthSprite1;
    public Sprite healthSprite2;
    public Sprite healthSprite3;
    public Sprite healthSprite4;
    public Sprite healthSprite5;
    public Sprite healthSprite6;
    public Sprite healthSprite7;
    public Sprite healthSprite8;

    Image[] images;

    // Start is called before the first frame update
    void Start()
    {
        images = gameObject.GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change()
    {
       
    }
}
