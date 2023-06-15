using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonForRestart : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement PM;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PM = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            PM.restart();

        if (Input.GetButtonDown("Fire2"))
            PM.restart();


    }
}
