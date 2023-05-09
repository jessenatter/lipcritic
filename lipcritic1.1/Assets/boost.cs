using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boost : MonoBehaviour
{
    public GameObject topleft;
    public GameObject bottomright;
    private float targetX;
    private float targetY;
    private Rigidbody2D rb;
    private float directionY;
    private float directionX;
    private float force = 1f;

    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        newtarget();
    }

    void Update()
    {
        if (transform.position.x == directionX && transform.position.y == directionY)
            newtarget();
    }

    private void newtarget()
    {
        targetX = Random.Range(topleft.transform.position.x, bottomright.transform.position.x);
        targetY = Random.Range(topleft.transform.position.y, bottomright.transform.position.y);

        directionY = targetY - transform.position.y;
        directionX = targetX - transform.position.x;

        Debug.Log(directionY);
        Debug.Log(directionX);

        rb.velocity = new Vector2(directionX, directionY).normalized * force;
    }
}
