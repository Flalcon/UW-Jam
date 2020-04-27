using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject EB, EL, poof, healthPiece;
    public float BT;
    public int enemyHealth;
    public int type;
    public float spd;
    public float bulletspd;
    public Sprite laserEye, buttereye;
    private Vector3 newpos;

    public AnimationClip butterfly, spewer, blaster;
    //private AnimatorOverrideController anim;
    private Animator anim;
    protected AnimatorOverrideController animatorOverrideController;

    void Start()
    {
        anim = GetComponent<Animator>();

        animatorOverrideController = new AnimatorOverrideController(anim.runtimeAnimatorController);
        anim.runtimeAnimatorController = animatorOverrideController;
        //anim = gameObject.GetComponent<AnimatorOverrideController>();

        //there are 2 types of enemy movement: straightforward and LERP
        //Lerp Enemies take longer to fire, but have more powerful attacks & more health
        //straightforward enemies have simpler attacks but start firing asap
        switch (type)
        {
            case 0:
              // animatorOverrideController["Enemy"] = spewer;
                spd = 0.5f;
                enemyHealth = 80;
                break;
            case 1:
                //animatorOverrideController["attack"] = spewer;
                spd = 2f;
                enemyHealth = 100;
                break;

            case 2:
                spd = 2f;
                enemyHealth = 40;
                gameObject.GetComponent<SpriteRenderer>().sprite = laserEye;
                animatorOverrideController["Enemy"] = butterfly;

                break;

            case 3:
                //animatorOverrideController["Enemy"] = null;
                spd = 20f;
                enemyHealth = 200;
                gameObject.GetComponent<SpriteRenderer>().sprite = laserEye;
                break;

        }
        bulletspd = 3;
        newpos = gameObject.transform.position;
    }

   
    void Update()
    {
        
        switch (type) {
            case 0:
                gameObject.transform.Translate(new Vector3(-spd * Time.deltaTime, 0, 0));
                if (BT <= 0)
                {
                    GameObject B = Instantiate(EB);
                    GameObject C = Instantiate(EB);
                    GameObject D = Instantiate(EB);
                    B.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion());
                    B.GetComponent<EnemyBullets>().dir = new Vector2(bulletspd, type * Random.Range(-bulletspd, bulletspd));
                    C.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion());
                    C.GetComponent<EnemyBullets>().dir = new Vector2(bulletspd, Random.Range(-bulletspd, bulletspd));
                    D.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion());
                    D.GetComponent<EnemyBullets>().dir = new Vector2(bulletspd, Random.Range(-bulletspd, bulletspd));
                    BT = 2;
                    anim.SetBool("Attacking", true);
                    
                }
                break;
            case 1:
                gameObject.transform.Translate(new Vector3(-spd * Time.deltaTime, 0, 0));
                if (BT <= 0)
                {
                    GameObject B = Instantiate(EB);
                    B.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion());
                    B.GetComponent<EnemyBullets>().dir = new Vector2(bulletspd, type * Random.Range(-bulletspd, bulletspd));
                    BT = 0.2f;
                    anim.SetBool("Attacking", true);
                }
                break;
            case 2:
                gameObject.transform.Translate(new Vector3(-spd * Time.deltaTime, Mathf.Sin(BT), 0));


                anim.SetBool("Attacking", true);
                break;
            case 3:

                if (newpos == gameObject.transform.position) {
                    newpos = new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y, gameObject.transform.position.z);
                    GameObject L = Instantiate(EL);
                    L.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion());
                }
                    gameObject.transform.SetPositionAndRotation(Vector3.Lerp(gameObject.transform.position, newpos, 1/spd), new Quaternion());
                break;

        }



        BT -= Time.deltaTime;

        if (enemyHealth <= 0 || gameObject.transform.position.x <= -20)
        {
            Destroy(gameObject);
            if (enemyHealth <= 0) 
            {
                var player = FindObjectOfType<PlayerMovement>();
                int pHealth = player.playerHealth;
                player.score++;
                if (pHealth < 8 && pHealth > 0) {
                    if (1/Random.Range(1, pHealth) == 1) {
                        var m = Instantiate(healthPiece);
                        m.transform.SetPositionAndRotation(gameObject.transform.position, new Quaternion());
                    }
                }
                Vector2 poofPos = GeneratePoofPosition();
                Instantiate(poof, poofPos, poof.transform.rotation);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player Bullet"))
        {
            Destroy(collision.gameObject);
            enemyHealth -= 20;
        }
    }

    public void Close() {

        anim.SetBool("Attacking", false);


    }

    Vector2 GeneratePoofPosition()
    {
        float yPos = transform.position.y;
        float xPos = transform.position.x;
        return new Vector2(xPos, yPos);
    }
}
