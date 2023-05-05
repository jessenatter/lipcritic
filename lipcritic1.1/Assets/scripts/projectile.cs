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
    public GameObject timer;
    private TimerScr TimerScr;
    public GameObject flash;
    private LipCriticFLASH LCF;

    public bool groundHit;
    public bool topHit;

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
        LCF = flash.GetComponent<LipCriticFLASH>();
        TimerScr = timer.GetComponent<TimerScr>();
        state = State.normal;
    }

    // Update is called once per frame
    void Update()
    {
        //close to ground

        int layer_mask = LayerMask.GetMask("Obsticle");
        RaycastHit2D groundcast = Physics2D.Raycast(transform.position, Vector2.down, 1.6f, layer_mask);
        if (groundcast == true)
            groundHit = true;
        else
            groundHit = false;

        //close to ceiling

        RaycastHit2D topcast = Physics2D.Raycast(transform.position, Vector2.up, 1.6f, layer_mask);
        if (topcast == true)
            topHit = true;
        else
            topHit = false;


        verticalMove = Input.GetAxisRaw("Vertical");

        switch (state)
        {
            default: 
            case State.normal:

            myrigidbody.velocity = new Vector2(direction * speed, (verticalMove * 7.5f));
                transform.localScale = new Vector3(1, 1, 1);
            break;

            case State.speed:

            myrigidbody.velocity = new Vector2(direction * speed * 2, (verticalMove * 11f));
                transform.localScale = new Vector3(1.2f, 1.2f, 1);
                break;
        }

    }

     public void OnTriggerEnter2D(Collider2D hitinfo)
    {
        enemyAI enemyAI = hitinfo.GetComponent<enemyAI>();
        if (enemyAI != null)
        {

            if (state == State.speed)
            {
                enemyAI.TakeDamage(1);
                hitenemy();
            }
            else
            {
                hitenemynospeed();
            }
         
        }

        NMEpatrol NMEpatrol = hitinfo.GetComponent<NMEpatrol>();
        if (NMEpatrol != null)
        {

            if (state == State.speed)
            {
                NMEpatrol.TakeDamage(1);
                hitenemy();
            }
            else
            {
                hitenemynospeed();
            }

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
        LCF.stop();
        Ccollider.enabled = false;
        gameObject.SetActive(false);
        PlayerMovement.playerControl();
        state = State.normal;
    }
    private void hitwall()
    {
        PlayerMovement.teleport();
        TimerScr.TimerDoneByWall();
        Deactivate();
    }
    private void hitenemy()
    {
      
    }
    public void timedone()
    {
        PlayerMovement.teleport();
        Deactivate();
    }

    public void speedSwitch()
    {
        if (state == State.normal)
        {
            state = State.speed;
            TimerScr.SpeedTimer();
            LCF.color();
        }

        else if (state == State.speed)
        {
            explode();
            TimerScr.TimerDoneByWall();
            LCF.stop();
        }
    }
    private void hitenemynospeed()
    {
        TimerScr.TimerDoneByWall();
        Deactivate();
    }
}
