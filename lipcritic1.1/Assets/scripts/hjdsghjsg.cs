using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hjdsghjsg : MonoBehaviour
{
    public GameObject ray;
    public projectile poop;

    // Start is called before the first frame update
    void Start()
    {
  
        ray = GameObject.FindGameObjectWithTag("ray");
        poop = ray.GetComponent<projectile>();
        poop.pee = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
