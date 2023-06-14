using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCooldown : MonoBehaviour
{
    public bool CanBeHit = true;
    public float HitTimer = 0f;
    public SpriteRenderer SR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HitTimer <= 0f)
        {
            CanBeHit = true;
        }
        else
        {
            HitTimer -= Time.deltaTime * .4f;
        }
        
    }

    public void HasHit()
    {
        HitTimer = 1f;
        CanBeHit = false;
    }

}
