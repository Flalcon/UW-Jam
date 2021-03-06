﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public int cursor = 0;
    public GameObject cur;
    private bool up, down, select, canMove;
    private float timer;
    public GameObject screen;
    private SpriteRenderer Sprite;
    private Color col;
    //public var col = screen.GetComponent<Renderer>().material.color;
    //currently too sleepy to deal with this, GN
    void Start()
    {
        up = down = select = false;
        canMove = true;
        timer = 2;
        //screen.GetComponent<Color>;
        // col = screen.GetComponent<SpriteRenderer>().color;
        //col.a = 0f;
        Sprite = screen.GetComponent<SpriteRenderer>();
        //screen.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
        Sprite.color = new Color(0f, 0f, 0f, 0f);

    }

    void Update()
    {
        
        if (canMove)
        {
            up = Input.GetKeyDown(("w")) || Input.GetKeyDown(KeyCode.UpArrow);
            down = Input.GetKeyDown("s") || Input.GetKeyDown(KeyCode.DownArrow);
            select = Input.GetKeyDown(KeyCode.Space);
        }
        if (up) { cursor--; }
        if (down) { cursor++; }
        cursor = Mathf.Clamp(cursor, 0, 2);

        cur.transform.SetPositionAndRotation(new Vector3(cur.transform.position.x, -cursor * 2, 0),new Quaternion());


        if (select)
        {
            timer = 0;
            canMove = false;
        }
        if (timer <= 1) {
            //change the alpha values of the current number making it look like its blinking in and out
            //make the bullet move to the edge of the screen
            cur.transform.Translate(Time.deltaTime * 20, 0, 0);
            //fadeout
            //Sprite.color = new Color(0f, 0f, 0f, timer);
            screen.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, (cur.transform.position.x)/15);
        }
        timer += Time.deltaTime;
        if (cur.transform.position.x > 15) {
            switch (cursor)
            {
                case 0:
                    SceneManager.LoadScene(1);
                    break;


                case 1:
                    SceneManager.LoadScene(2);
                    break;

                case 2:
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                   Application.Quit();
                #endif
                    break;



            }
        }

    }
}
