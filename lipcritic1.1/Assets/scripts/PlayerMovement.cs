using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public SpriteRenderer spriteR;

    public float runspeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    private int health = 5;

    public GameObject deathscreen;
    public GameObject deadbody;
    public GameObject logic;
    public GameObject grassController;

    public Transform firepoint;
    public GameObject balls;
    public projectile projectileV;
    private float x;
    private float firex;
    private int flipped;

    private LogicScript Lscript;

    private grassController grass;

    public GameObject top;
    public GameObject bottom;
    public GameObject left;
    public GameObject right;

    private collidingSCR T;
    private collidingSCR B;
    private collidingSCR L;
    private collidingSCR R;

    private float V = 0;
    private float H = 0;

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
        grassController = GameObject.FindGameObjectWithTag("grass");
        grass = grassController.GetComponent<grassController>();
        projectileV = balls.GetComponent<projectile>();
        T = top.GetComponent<collidingSCR>();
        B = bottom.GetComponent<collidingSCR>();
        L = left.GetComponent<collidingSCR>();
        R = right.GetComponent<collidingSCR>();
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
                    //grass.grassup();

                }

                controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
                jump = false;

                //if (horizontalMove > 0)
                //{
                //    grass.grassright();
                //    grass.grassleftstop();
                //}

                //if (horizontalMove < 0)
                //{
                //    grass.grassleft();
                //    grass.grassrightstop();
                //}
                //if (horizontalMove == 0)
                //{
                //    grass.grassrightstop();
                //    grass.grassleftstop();
                //}

                break;

            case State.ray:

                controller.Move(0f, false, false);

                break;
        }

    }

    public void takehit()
    {
        spriteR.color = new Color(1, 0, 0, 1);
        health--;
        hitstop();
        if (health == 0)
            die();
    }
    private void die()
    {
        // deathscreen.SetActive(true);
        // shooting.playercontrol = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NMEproj")
            takehit();

    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
        grass.grassjumpstop();
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
            balls.transform.position = firepoint.position;
            projectileV.SetDirection(flipped);
            state = State.ray;


        }
        else
        {
            projectileV.speedSwitch();
        }
    }

    public void playerControl()
    {
        state = State.player;
    }

    public void teleport()
    {
        transform.position = new Vector2(balls.transform.position.x, balls.transform.position.y + 1.1f);

        if (T.hit == true)
            V = V - 1.1f;
        if (B.hit == true)
            V = V + 1.1f;
        if (L.hit == true)
            H = H + 1.1f;
        if (R.hit == true)
            H = H - 1.1f;
    }
}
