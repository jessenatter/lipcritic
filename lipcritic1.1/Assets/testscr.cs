using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscr : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            negvelocity();

        }
    }

    private void negvelocity()

    {

    rb.velocity = -rb.velocity;

    }
}
