using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed = 10f;
    public CircleCollider2D Ccollider;
    private float direction;
    private PlayerMovement PlayerMovement;
    public Rigidbody2D myrigidbody;
    public float horizontalMove = 10f;
    public float verticalMove = 0f;
    public GameObject player;
    public GameObject explodeO;
    private int NMEmax;
    private int NMEcurrent;

    private enum State
    {
        normal,
        speed,
        speed2,
        speed3,
        speed4,
    }

    private State state;

    // Start is called before the first frame update
    void Start()
    {
        Ccollider = GetComponent<CircleCollider2D>();
        PlayerMovement = player.GetComponent<PlayerMovement>();
        state = State.normal;
        NMEmax = 1;
    }

    // Update is called once per frame
    void Update()
    {
        verticalMove = Input.GetAxisRaw("Vertical");

        switch (state)
        {
            default: 
            case State.normal:

            myrigidbody.velocity = new Vector2(direction * speed, (verticalMove * 7.5f));
                NMEmax = 1;
                break;

            case State.speed:

            myrigidbody.velocity = new Vector2(direction * speed * 2, (verticalMove * 9f));
                NMEmax = 2;
                break;

            case State.speed2:

            myrigidbody.velocity = new Vector2(direction * speed * 3, (verticalMove * 11f));
                NMEmax = 3;
                break;

            case State.speed3:

            myrigidbody.velocity = new Vector2(direction * speed * 4, (verticalMove * 13f));
                NMEmax = 4;
                break;

            case State.speed4:

            myrigidbody.velocity = new Vector2(direction * speed * 5, (verticalMove * 17f));
                NMEmax = 5;
                break;
        }

    }

     public void OnTriggerEnter2D(Collider2D hitinfo)
    {
        enemyAI enemyAI = hitinfo.GetComponent<enemyAI>();
        if (enemyAI != null)
        {
            enemyAI.TakeDamage(1);
            hitenemy();
        }
        NMEprojectile NMEprojectile = hitinfo.GetComponent<NMEprojectile>();
        if (NMEprojectile != null)
        {
            if(state == State.speed)
            {
                NMEprojectile.explode();
            }
        }
        if (hitinfo.tag == "wall")
        {
            hitwall();
        }

    }

   

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        Ccollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector2(localScaleX, transform.localScale.y);
    }

    public void explode()
    {
        Instantiate(explodeO, transform.position, Quaternion.identity);
        Deactivate();
    }
    private void Deactivate()
    {
        Ccollider.enabled = false;
        gameObject.SetActive(false);
        PlayerMovement.playerControl();
        state = State.normal;
    }
    private void hitwall()
    {

        Deactivate();
    }
    private void hitenemy()
    {
        NMEcurrent++;

        if (NMEcurrent >= NMEmax)
            Deactivate();

    }

    public void speedSwitch()
    {
        if (state == State.normal)
            state = State.speed;

        else if (state == State.speed)
            state = State.speed2;

        else if (state == State.speed2)
            state = State.speed3;

        else if (state == State.speed3)
            state = State.speed4;

        else if (state == State.speed4)
            explode();
    }
}
