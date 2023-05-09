using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boost : MonoBehaviour
{  
    private Rigidbody2D rb;
    public GameObject maxX;
    public GameObject maxY;
    public GameObject minX;
    public GameObject minY;

    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        newdirection();
    }

    void Update()
    {
        if (transform.position.x > maxX.transform.position.x)
            newdirection();
        if (transform.position.y > maxY.transform.position.y)
            newdirection();
        if (transform.position.x < minX.transform.position.x)
            newdirection();
        if (transform.position.x < minY.transform.position.y)
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
