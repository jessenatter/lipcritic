using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 1;

    public GameObject healed;
    public float speed;
    public float stoppingDistance;
    public float retreatdistance;

    public Transform player;

    private float timeBTW;
    public float startTimeBTW;

    public GameObject NMEprojectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBTW = startTimeBTW;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatdistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatdistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }


        //shooting

        if(timeBTW <= 0)
        {
            Instantiate(NMEprojectile, transform.position, Quaternion.identity);
            timeBTW = startTimeBTW;
        }
        else
        {
            timeBTW -= Time.deltaTime;
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }

    }

    void Die ()
    {
        Instantiate(healed, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

   
}
