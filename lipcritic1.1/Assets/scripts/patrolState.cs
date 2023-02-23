using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolState : state
{
    public attackState attackState;
    public bool canSeeThePlayer;

    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;

    public GameObject aim;

    public override state RunCurrentState()
    {
        if (canSeeThePlayer)
        {
            return attackState;
        }
        else
        {
            return this;
        }
    }

    private void Start()
    {
        aim.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

        if (groundInfo.collider == false)
        {
            if(movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
