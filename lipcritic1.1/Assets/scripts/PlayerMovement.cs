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

    private bool canboost;

    public GameObject GotThing;
    private goAway goAway;

    public enum State
    {
        player,
        ray,
        dead,
    }

    public State state;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        projectileV = balls.GetComponent<projectile>();
        goAway = GotThing.GetComponent<goAway>();
        TimerScr = timer.GetComponent<TimerScr>();
        rb = GetComponent<Rigidbody2D>();

        animator.SetBool("isdead", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (deathcord.transform.position.y > transform.position.y)
        {
            die();
        }

        int layer_mask = LayerMask.GetMask("Obsticle");
        RaycastHit2D playercast = Physics2D.Raycast(groundDetection.position, Vector2.down, .1f, layer_mask);
        if (playercast == true)
            animator.SetBool("isJumping", false);

        if (HitTimer > 0)
            HitTimer -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
            Shoot();

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
        }

    }

    IEnumerator WaitForSpawn()
    {
        while (Time.timeScale != 1.0f)
            yield return null;

        spriteR.color = new Color(1f, 1f, 1f, 1f);
    }

    public void takehit()
    {
        Screenshake.Instance.shake(5f, .5f);
        health = health - 1;
        if (health == 0)
            die();

        spriteR.color = new Color(1f, 0f, 0f, 1f);
        FindObjectOfType<Hitstop>().stop(.3f);

        StartCoroutine(WaitForSpawn());


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

        if (collision.tag == "boost")
        {
            //canboost = true;
            boost();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canboost = false;
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
        }

        if (collision.gameObject.tag == "enemy")
        {

            if (collision.gameObject.transform.position.x > transform.position.x)
                rb.velocity = new Vector2(-10f, 10f);
            else if (collision.gameObject.transform.position.x < transform.position.x)
                rb.velocity = new Vector2(10f, 10f);

            takehit();
        }
    }


    void Shoot()
    {
            if (state == State.player)
            {
            if (TimerScr.canshoot == true)
            {
                balls.transform.position = firepoint.position;
                projectileV.SetDirection(flipped);
                state = State.ray;
                TimerScr.startTimer();
            }
            else if (canboost == true)
                boost();
            else
                cantshoot();
            }
            else
                projectileV.speedSwitch();
    }

    public void playerControl()
    {
        state = State.player;
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
    private void boost()
    {
        TimerScr.boost();
        GotThing.SetActive(true);
      //  goAway.timecountupstart();
    }
}
