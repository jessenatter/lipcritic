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
                transform.localScale = new Vector3(1, 1, 1);
            break;

            case State.speed:

            myrigidbody.velocity = new Vector2(direction * speed * 2, (verticalMove * 11f));
                NMEmax = 2;
                transform.localScale = new Vector3(1.2f, 1.2f, 1);
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
        PlayerMovement.teleport();
        Deactivate();
    }
    private void hitenemy()
    {
        PlayerMovement.teleport();
        NMEcurrent++;

        if (NMEcurrent >= NMEmax)
            Deactivate();

    }

    public void speedSwitch()
    {
        if (state == State.normal)
            state = State.speed;

        else if (state == State.speed)
            explode();
    }
}
