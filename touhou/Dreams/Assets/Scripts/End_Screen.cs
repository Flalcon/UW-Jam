using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Screen : MonoBehaviour
{
    private float timer;
    private bool s;

    void Start()
    {
        s = false;
        timer = 0;
    }

    void Update()
    {
        if (s)
        {
            GetComponent<AudioSource>().volume = timer;
            timer -= 0.2f * Time.deltaTime;

            if (timer <= 0)
            {
                SceneManager.LoadScene(0);

            }
        }
        else {
            timer += 0.2f * Time.deltaTime;
            timer = Mathf.Clamp(timer, 0, 1);
        }


        if (Input.anyKeyDown && timer >= 0.75f)
        {
            s = true;
        }

        GetComponent<SpriteRenderer>().color = new Color(timer, timer, timer, 1);
    }
}
