using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool canMove = true;
    public float hsp = 0; public float vsp = 0;
    public float spd = 0.01f;
    public int playerHealth = 8;
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
            Instantiate(LS);
            Destroy(gameObject);
            
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

        hsp = Mathf.Clamp(hsp, -5, 5);
        vsp = Mathf.Clamp(vsp, -5, 5);

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

        gameObject.transform.Translate(new Vector3(hsp * Time.deltaTime,vsp * Time.deltaTime,0));
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
    }

    IEnumerator iFrameRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        isInvincible = false;
    }
}
