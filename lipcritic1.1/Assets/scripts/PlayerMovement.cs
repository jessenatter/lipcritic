using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public SpriteRenderer spriteR;

    public float runspeed = 40f;

    public shooting shooting;

    float horizontalMove = 0f;
    bool jump = false;

    private int health = 5;

    public GameObject deathscreen;
    public GameObject deadbody;
    public GameObject logic;

    private LogicScript Lscript;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic");
        Lscript = logic.GetComponent<LogicScript>();
        shooting = GetComponent<shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (shooting.playercontrol)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }
        }
        else
        {
            jump = false;
            horizontalMove = 0;
        }
    }

    private void FixedUpdate()
    {
        if (shooting.playercontrol)
        {
            //Move Chr
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
        else
        {
            controller.Move(0f, false, false);
        }
    }
    public void takehit()
    {
        spriteR.color = new Color(1,0,0,1);
        health--;
        hitstop();
        if (health == 0)
            die();
    }
    private void die()
    {
        deathscreen.SetActive(true);
        shooting.playercontrol = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NMEproj")
            takehit();

    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void hitstop()
    {
        Lscript.hitstop();
    }

    public void resumecolor()
    {
        spriteR.color = new Color(1, 1, 1, 1);
    }
}
