﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private float ypos;
    public GameObject screen;
    private SpriteRenderer Sprite;
    public GameObject aud;

    void Start()
    {
        screen.SetActive(true);
        var a = aud.GetComponent<AudioSource>();
        a.Stop();
    }
    
    void Update()
    {

        ypos = gameObject.transform.position.y;
        if (ypos< 0) {
            gameObject.transform.Translate(0,-Mathf.Lerp(ypos,0,1/5) * Time.deltaTime,0);
        }
        screen.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, (6+ypos)/6);
        if (Input.anyKeyDown && ypos > -0.2f) {
            SceneManager.LoadScene(0);
        }
    }
}
