using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runspeed = 40f;

    private shooting shooting;

    float horizontalMove = 0f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        shooting = GetComponent<shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting.playercontrol)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                
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
}
