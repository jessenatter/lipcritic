using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public SpriteRenderer spriteR;
    public Rigidbody2D rb;
    public BoxCollider2D Bcollider;
    public float runspeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    public int health = 3;
    public GameObject deathscreen;
    public GameObject deadbody;
    public Transform firepoint;
    public GameObject balls;
    public projectile projectileV;
    private float x;
    private float firex;
    private int flipped;
    public GameObject timer;
    private TimerScr TimerScr;
    public Transform groundDetection;
    private float HitTimer;
    public GameObject deathcord;
    public HitCooldown HC;
    public float hurt;
    private CircleCollider2D Ccollider;
    public bool meemo;
    private Vector2 respawnPoint;
    public GameObject heart;
    public HeartScr HS;
    public Screenshake SS;

    public enum State
    {
        player,
        ray,
        dead,
        respawning,
    }

    public State state;
    public bool canusehand = true;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        projectileV = balls.GetComponent<projectile>();
        rb = GetComponent<Rigidbody2D>();
        Bcollider = GetComponent<BoxCollider2D>();
        Ccollider = GetComponent<CircleCollider2D>();
        animator.SetBool("isdead", false);
        TimerScr = timer.GetComponent<TimerScr>();
        runspeed = 30f;
        HS = heart.GetComponent<HeartScr>();
        health = 3;
        setrespawnpoint(transform.position);
        HS.healthchange();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("Menu");
        }


        if (deathcord.transform.position.y > transform.position.y)
        {
            if (state == State.player)
            {
                diebyfall();
            }
             
        }

        if (HitTimer > 0)
            HitTimer -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
            Shoot();

        if (HC.CanBeHit == false)
        {
            hurt = 1 - HC.HitTimer;
            spriteR.color = new Color(1f, hurt, hurt, 1f);
        }
        else
        {
            spriteR.color = new Color(1f, 1f, 1f, 1f);
        }

        switch (state)
        {
            default:
            case State.player:

    

                //nonsense to see if flipping
                x = transform.position.x;
                firex = firepoint.position.x;

                if (firex > x)
                    flipped = 1;
                if (firex < x)
                    flipped = -1;

                horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
                animator.SetFloat("speed", Mathf.Abs(horizontalMove));

                if (Input.GetButtonDown("Jump"))
                {
                    jump = true;
                    animator.SetBool("isJumping", true);
                }

                controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
                jump = false;

                break;

            case State.ray:

                controller.Move(0f, false, false);

                break;

            case State.dead:

                controller.Move(0f, false, false);
                animator.SetBool("isdead", true);
                Time.timeScale = 0;

                break;

            case State.respawning:

                controller.Move(0f, false, false);

                break;
        }

    }


    public void takehit()
    {
        if (HC.CanBeHit)
        {
            HC.HasHit();
            //screenshake
            //hitstop
            SS.shake(1f, .5f);
            health = health - 1;
            HS.healthchange();
            if (health == 0)
                die();
        }
        else
        {
       
        }

    }
    private void die()
    {
        deathscreen.SetActive(true);
        state = State.dead;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NMEproj")
        {
            Destroy(collision.gameObject);
            takehit();
        }
        if(collision.tag =="checkpoint")
        {
            setrespawnpoint(transform.position);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NMEpatrol")
        {

            if (collision.gameObject.transform.position.x > transform.position.x)
                rb.velocity = new Vector2(-10f, 10f);
            else if (collision.gameObject.transform.position.x < transform.position.x)
                rb.velocity = new Vector2(10f, 10f);

            takehit();

            NMEpatrol meem;
            meem = collision.gameObject.GetComponent<NMEpatrol>();
            meem.wallhit();
        }

        if (collision.gameObject.tag == "enemy")
        {

            if (collision.gameObject.transform.position.x > transform.position.x)
                rb.velocity = new Vector2(-10f, 10f);
            else if (collision.gameObject.transform.position.x < transform.position.x)
                rb.velocity = new Vector2(10f, 10f);

            takehit();
        }
        if(collision.gameObject.tag == "wall")
        {
            animator.SetBool("isJumping", false);
        }
    }


    void Shoot()
    {
        if (canusehand == true)
        {
            if (state == State.player)
            {
                if (TimerScr.canshoot == true)
                {
                    balls.transform.position = firepoint.position;
                    projectileV.SetDirection(flipped);
                    projectileV.activated();
                    state = State.ray;
                    Bcollider.enabled = false;
                    Ccollider.enabled = false;
                    animator.SetBool("invisible", true);
                    animator.SetFloat("speed", 0f);
                    animator.SetBool("isJumping", false);
                    TimerScr.SwitchToCountDown();
                    gameObject.SetActive(false);
                }
                else
                    cantshoot();
            }
            else
                projectileV.speedSwitch();
        }
    }

    public void playerControl()
    {
        gameObject.SetActive(true);
        state = State.player;
        Bcollider.enabled = true;
        Ccollider.enabled = true;
        animator.SetBool("invisible", false);
    }

    public void teleport()
    {
        if (projectileV.groundHit == true)
            transform.position = new Vector2(balls.transform.position.x, balls.transform.position.y + 2f);
        else if (projectileV.topHit == true)
            transform.position = new Vector2(balls.transform.position.x, balls.transform.position.y - 2f);
        else
            transform.position = new Vector2(balls.transform.position.x, balls.transform.position.y);

    }

    private void cantshoot()
    {
        //cant shoot stuff
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void diebyfall()
    {
        //screenshake
        //hitstop

        health -= 1;
        HS.healthchange();
        if (health == 0)
            die();
        transform.position = respawnPoint;
        //visual stuff, wait to play again
        animator.SetTrigger("respawn");
        state = State.respawning;
        StartCoroutine(wait());

    }

    public void setrespawnpoint(Vector2 position)
    {
        respawnPoint = (Vector2)position;
    }

    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(1.3f);
        state = State.player;
    }
}
