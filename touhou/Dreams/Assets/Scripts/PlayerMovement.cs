using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool canMove = true;
    public float hsp = 0; public float vsp = 0;
    public float spd = 0.01f;
    public int playerHealth = 8;
    private float posx, posy;
    public GameObject PB, LS;
    public int score;
    private bool isInvincible = false;



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

        if (playerHealth <= 0)
        {
            LS.SetActive(true);
            Destroy(gameObject);
            
        }
    }

    public void Movement() {
        posx = gameObject.transform.position.x;
        posy = gameObject.transform.position.y; 
        bool up = Input.GetKey(("w")) || Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow);
         
       // bool bomb = Input.GetKey("n") || Input.GetKey(KeyCode.Space);
        if (up)   { vsp += spd; }
        if (down) { vsp -= spd; }
        if (left) { hsp -= spd; }
        if (right) {hsp += spd; }

        hsp = Mathf.Clamp(hsp, -5, 5);
        vsp = Mathf.Clamp(vsp, -5, 5);


        if (Mathf.Abs(posx + hsp * Time.deltaTime) < 8.5f)
        {
            gameObject.transform.Translate(new Vector3(hsp * Time.deltaTime, 0, 0));
        }
        else
        {
            hsp = 0;
            gameObject.transform.SetPositionAndRotation(new Vector3(Mathf.Sign(posx) * 8.5f, posy, 0), new Quaternion());
        }

        if (Mathf.Abs(posy + vsp * Time.deltaTime) < 4.5f)
        {
            gameObject.transform.Translate(new Vector3( 0, vsp * Time.deltaTime, 0));
        }
        else
        {
            vsp = 0;
            while (Mathf.Abs(gameObject.transform.position.y) < 4.5f) {
                //gameObject.transform.SetPositionAndRotation(new Vector3(posx, Mathf.Sign(posy) * 4.5f, 0), new Quaternion());
                gameObject.transform.Translate(new Vector3(0, Mathf.Sign(posy) * 0.00001f, 0));

            }
        }
        /*
        if (Mathf.Abs(posy + vsp) < 9)
        {
            gameObject.transform.Translate(new Vector3(0, vsp * Time.deltaTime, 0));
        }
        else {
            while (gameObject.transform.position.y <= Mathf.Sign(vsp) * 9) {
                gameObject.transform.Translate(0.0001f,0,0);
            }
           // gameObject.transform.SetPositionAndRotation(new Vector3(posx, Mathf.Sign(vsp) * 9, 0), new Quaternion());
            vsp = 0;
        }
        */
        //gameObject.transform.Translate(new Vector3(hsp * Time.deltaTime, vsp * Time.deltaTime, 0));

        if (up == down) {
            if (Mathf.Abs(vsp) > 0.2)
            {
                vsp *= 0.8f;
            }
            else { vsp = 0; }
        }

        if (right == left)
        {
            if (Mathf.Abs(hsp) > 0.2)
            {
                hsp *= 0.8f;
            }
            else { hsp = 0; }
        }

       
       // gameObject.transform.Translate(new Vector3(hsp * Time.deltaTime,vsp * Time.deltaTime,0));
    }

    public void GameOver() 
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Bullet") || collision.gameObject.CompareTag("Laser") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            
            if (isInvincible == false)
            {
                playerHealth--;
                isInvincible = true;
                StartCoroutine(iFrameRoutine());
            } 
        }

        if (collision.gameObject.CompareTag("Health"))
        {
            playerHealth++;
            playerHealth = Mathf.Clamp(playerHealth, 0, 8);
            Destroy(collision.gameObject);
        }
    }

    IEnumerator iFrameRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        isInvincible = false;
    }
}
