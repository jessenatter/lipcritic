using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackState : state
{
    public patrolState patrolState;
    public bool canSeeThePlayer;

    public float speed;
    public float stoppingDistance;
    public float retreatdistance;

    public Transform player;

    public GameObject aim;

    public override state RunCurrentState()
    {
        if (!canSeeThePlayer)
        {
            return patrolState;
        }
        else
        {
            return this;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        aim.SetActive(true);
    }

    private void Update()
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
    }
}
