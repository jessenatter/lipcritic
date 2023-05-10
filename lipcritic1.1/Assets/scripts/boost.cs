using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boost : MonoBehaviour
{  
    private Rigidbody2D rb;
    private float maxX;
    private float maxY;
    private float minX;
    private float minY;

    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        newdirection();
        maxX = transform.position.x + 5;
        minX = transform.position.x - 5;
        maxY = transform.position.y + 5;
        minY = transform.position.y - 5;

    }

    void Update()
    {
        if (transform.position.x > maxX)
            newdirection();
        if (transform.position.x < minX)
            newdirection();
        if (transform.position.y > maxY)
            newdirection();
        if (transform.position.y < minY)
            newdirection();
    }

    private void newdirection()
    {
        rb.velocity = new Vector2(Random.Range(-100,100), Random.Range(-100, 100)).normalized;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "trigger")
            newdirection();
    }
}
