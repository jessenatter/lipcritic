using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CANNOT : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement PM;

    // Start is called before the first frame update
    void Start()
    {
        PM = player.GetComponent<PlayerMovement>();
        PM.canusehand = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
