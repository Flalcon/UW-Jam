using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private float ypos;

    void Start()
    {
        
    }
    
    void Update()
    {
        ypos = gameObject.transform.position.y;
        if (ypos< 0) {
            gameObject.transform.Translate(0,-Mathf.Lerp(ypos,0,1/5) * Time.deltaTime,0);
        }

        if (Input.anyKeyDown && ypos > -0.2f) {
            SceneManager.LoadScene(1);
        }
    }
}
