using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shooting : MonoBehaviour
{
    public Transform firepoint;
    public bool playercontrol = true;
    public GameObject balls;
    public projectile projectileV;
    private float x;
    private float firex;
    private int flipped;


    // Start is called before the first frame update
    void Start()
    {
        projectileV = balls.GetComponent<projectile>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        //nonsense to see if flipping
        x = transform.position.x;
        firex = firepoint.position.x;

        if (firex > x)
            flipped = 1;
        if (firex < x)
            flipped = -1;
       
    }

    void Shoot()
    {
        if (playercontrol)
        {
            balls.transform.position = firepoint.position;
            playercontrol = false;
            projectileV.SetDirection(flipped);


        }
        else
        {
            projectileV.explode();
            playercontrol = true;
        }
    }
}
