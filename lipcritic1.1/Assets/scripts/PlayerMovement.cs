using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public SpriteRenderer spriteR;

    public float runspeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    private int health = 3;

    public GameObject deathscreen;
    public GameObject deadbody;
    public GameObject logic;

    public Transform firepoint;
    public GameObject balls;
    public projectile projectileV;
    private float x;
    private float firex;
    private int flipped;

    private LogicScript Lscript;
    public GameObject timer;
    private TimerScr TimerScr;

    public GameObject heart;
    private Image HEART;

    public GameObject top;
    public GameObject bottom;

    private collidingSCR T;
    private collidingSCR B;

    public enum State
    {
        player,
        ray,
    }

    public State state;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic");
        Lscript = logic.GetComponent<LogicScript>();
        projectileV = balls.GetComponent<projectile>();
        TimerScr = timer.GetComponent<TimerScr>();
        HEART = heart.GetComponent<Image>();
        T = top.GetComponent<collidingSCR>();
        B = bottom.GetComponent<collidingSCR>();
    }

    // Update is called once per frame
    void Update()
    {
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
        }

    }

    public void takehit()
    {
        spriteR.color = new Color(1, 0, 0, 1);
        health = health - 1;
        hitstop();
        if (health == 0)
            die();

        HEART.fillAmount = health * 0.33f;
    }
    private void die()
    {
        // deathscreen.SetActive(true);
        // shooting.playercontrol = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NMEproj")
        {
            Destroy(collision.gameObject);
            takehit();
        }
            

    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void hitstop()
    {
        Lscript.hitstop(.2f);
        resumecolor();
    }

    public void resumecolor()
    {
        spriteR.color = new Color(1, 1, 1, 1);
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
        if (B.hit == true)
            transform.position = new Vector2(balls.transform.position.x, balls.transform.position.y + 2f);
        else if (T.hit == true)
            transform.position = new Vector2(balls.transform.position.x, balls.transform.position.y - 2f);
        else
            transform.position = new Vector2(balls.transform.position.x, balls.transform.position.y);

    }

    private void cantshoot()
    {
        //cant shoot stuff
    }
}
