using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScr : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement PlayerMovement;
    private float health;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement = player.GetComponent<PlayerMovement>();
        animator = animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Health", PlayerMovement.health);
    }
}
