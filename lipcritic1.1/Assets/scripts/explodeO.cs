using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeO : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + 1f;
        if (timer == 20f)
            Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NMEproj")
        {
            NMEprojectile NMEprojectile = collision.GetComponent<NMEprojectile>();
            NMEprojectile.explode();
        }
    }

}
