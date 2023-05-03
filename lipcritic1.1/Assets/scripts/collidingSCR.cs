using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidingSCR : MonoBehaviour
{
    public bool hit = false;
    private BoxCollider2D BCollider;

    // Start is called before the first frame update
    void Start()
    {
        BCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall")
            hit = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hit = false;
    }
}
