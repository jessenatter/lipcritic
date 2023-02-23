using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poofSCR : MonoBehaviour
{
    private int destroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destroy++;
        if (destroy == 5)
            Destroy(gameObject);
    }
}
