using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMEprojectile : MonoBehaviour
{
    private GameObject target;
    private Vector3 targetpos;
    private Rigidbody2D rb;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        targetpos = target.transform.position;
        Vector3 direction = targetpos - transform.position;
        Vector3 rotation = transform.position - targetpos;
        rb.velocity = new Vector2(direction.x, direction.y + 1f).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            hitplayer();
        if (collision.tag == "wall")
            DestroyProjectile();
        if (collision.tag == "explode!")
            explode();
    }

    private void hitplayer()
    { 
        DestroyProjectile();
    }
    
   public void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    public void explode()
    {
        Debug.Log("poop");
        rb.velocity = -rb.velocity;

    }

}
