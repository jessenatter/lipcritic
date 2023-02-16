using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed = 10f;
    public CircleCollider2D Ccollider;
    private float direction;
    private shooting shooting;
    public Rigidbody2D myrigidbody;
    public float horizontalMove = 10f;
    public float verticalMove = 0f;
    public GameObject player;
    private float offset;
    public GameObject explodeO;

    // Start is called before the first frame update
    void Start()
    {
        Ccollider = GetComponent<CircleCollider2D>();
        shooting = player.GetComponent<shooting>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!shooting.playercontrol)
        {
            //setting var values buyt not movment bc u have to use fixed update ig
            verticalMove = Input.GetAxisRaw("Vertical");
            offset = 0f;

        }
    }

    private void FixedUpdate()
    {
        if (!shooting.playercontrol)
        {
            //movement
            myrigidbody.velocity = new Vector2(15f * direction, (verticalMove * 7.5f) + offset);
        }
    }

     public void OnTriggerEnter2D(Collider2D hitinfo)
    {
        enemy enemy = hitinfo.GetComponent<enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(1);
            hitenemy();
        }
        if(hitinfo.tag == "wall")
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
        shooting.playercontrol = true;
    }
    private void hitwall()
    {

        Deactivate();
    }
    private void hitenemy()
    {

        Deactivate();
    }
}
