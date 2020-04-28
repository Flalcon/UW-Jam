using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    private float timer;
    public GameObject aud;

    void Start()
    {
        timer = 1;
    }

    void Update()
    {
        aud.GetComponent<AudioSource>().volume = timer;
        GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1-timer);

        if (Input.anyKeyDown && timer <= 0)
        {
            SceneManager.LoadScene(3);
        }
        timer -= 0.2f * Time.deltaTime;
    }
}
