using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScr : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement PlayerMovement;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement = player.GetComponent<PlayerMovement>();
        animator = animator.GetComponent<Animator>();
    }

    public void healthchange()
    {
        if (PlayerMovement.health == 0f)
            animator.SetTrigger("heartEmpty");
        if (PlayerMovement.health == 1f)
            animator.SetTrigger("heart1");
        if (PlayerMovement.health == 2f)
            animator.SetTrigger("heart2");
        if (PlayerMovement.health == 3f)
            animator.SetTrigger("heart3");
    }
}
