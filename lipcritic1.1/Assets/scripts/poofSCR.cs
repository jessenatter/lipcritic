using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poofSCR : MonoBehaviour
{
    private float destroy;

    // Start is called before the first frame update
    void Start()
    {
        destroy = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        destroy += Time.deltaTime;

        if (destroy == .01f)
        {
            gameObject.SetActive(false);
        }
            
    }
}
