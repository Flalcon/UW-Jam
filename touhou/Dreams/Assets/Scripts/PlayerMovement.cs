using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool canMove = true;
    public float hsp = 0; public float vsp = 0;
    public float spd = 0.01f;
    public GameObject PB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) {
           Movement();
        }

        bool shoot = Input.GetKeyDown("n") || Input.GetKeyDown(KeyCode.Space);
        if (shoot) {
           GameObject B = Instantiate(PB);
            B.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion());
        }

    }

    public void Movement() {
        bool up = Input.GetKey(("w")) || Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow);
         
       // bool bomb = Input.GetKey("n") || Input.GetKey(KeyCode.Space);
        if (up)   { vsp += spd; }
        if (down) { vsp -= spd; }
        if (left) { hsp -= spd; }
        if (right) {hsp += spd; }

        hsp = Mathf.Clamp(hsp, -1, 1);
        vsp = Mathf.Clamp(vsp, -2, 2);

        if (up == down) {
            if (Mathf.Abs(vsp) > 0.2)
            {
                vsp *= 0.9f;
            }
            else { vsp = 0; }
        }

        if (right == left)
        {
            if (Mathf.Abs(hsp) > 0.2)
            {
                hsp *= 0.9f;
            }
            else { hsp = 0; }
        }

        gameObject.transform.Translate(new Vector3(hsp * Time.deltaTime,vsp * Time.deltaTime,0));
    }


}
