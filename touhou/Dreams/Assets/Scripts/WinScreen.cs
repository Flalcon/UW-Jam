using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    private float timer;
    public GameObject aud, i1, i2;

    void Start()
    {
        timer = 1;
    }

    void Update()
    {
        aud.GetComponent<AudioSource>().volume = timer;
        GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1-timer);
        i1.GetComponent<Image>().color = new Color(1f, 1f, 1f,  timer);
        i2.GetComponent<Image>().color = new Color(1f, 1f, 1f,  timer);
        if (Input.anyKeyDown && timer <= 0)
        {
            SceneManager.LoadScene(3);
        }
        timer -= 0.2f * Time.deltaTime;
    }
}
