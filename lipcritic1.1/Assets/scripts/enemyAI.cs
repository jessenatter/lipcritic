using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    private enum State
    {
        patrol,
        attack,
    }

    private State state;

    private bool attackStarted;
    private bool patrolStarted;

    public GameObject warning;

    //health stuff
    public int health = 1;

    public GameObject healed;
    //patrol stuff
    public bool canSeeThePlayer = false;

    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;
    public Transform playerDetection;

    public GameObject aim;

    //attack stuff
    public float stoppingDistance;
    public float retreatdistance;

    public Transform player;
    public Transform warningpos;

    private float firex;
    private bool flipped;
    private float x;


    // Start is called before the first frame update
    void Start()
    {
        aim.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        state = State.patrol;
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        firex = playerDetection.position.x;

        if (firex > x)
            flipped = true;
        if (firex < x)
            flipped = false;

        if (flipped)
        {
            int layer_mask = LayerMask.GetMask("Player");
            RaycastHit2D playercast = Physics2D.Raycast(playerDetection.position, Vector2.right, 10000f, layer_mask);
            if (playercast == true)
                canSeeThePlayer = true;
            else
                canSeeThePlayer = false;


        }
        else
        {
            int layer_mask = LayerMask.GetMask("Player");
            RaycastHit2D playercast = Physics2D.Raycast(playerDetection.position, Vector2.left, 10000f, layer_mask);
            if (playercast == true)
                canSeeThePlayer = true;
            else
                canSeeThePlayer = false;

        }

            switch (state)
        {
            default:
            case State.patrol:

                //patrol stuff

                if (!patrolStarted)
                    PatrolStart();

                transform.Translate(Vector2.right * speed * Time.deltaTime);

                RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

                if (groundInfo.collider == false)
                {
                    if (movingRight)
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

                if (canSeeThePlayer)
                    state = State.attack;

                break;

            case State.attack:

                //attack stuff

                if (!attackStarted)
                    AttackStart();

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

                //find reason to switch back to patrol state, maybe timer for cant see player for certian ammount of time?
                   // state = State.patrol;

                break;
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

    void Die()
    {
        Instantiate(healed, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void PatrolStart()
    {
        attackStarted = false;
        aim.SetActive(false);
        patrolStarted = true;
    }
    private void AttackStart()
    {
        Instantiate(warning, warningpos.position, Quaternion.identity);

        patrolStarted = false;
        aim.SetActive(true);
        attackStarted = true;
    }
}
