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

            break;

            case State.speed:

            myrigidbody.velocity = new Vector2(direction * speed * 2, (verticalMove * 9f));

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

        Deactivate();
    }

    public void speedSwitch()
    {
        state = State.speed;
    }
}
