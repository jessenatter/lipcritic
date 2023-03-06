using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassScript : MonoBehaviour
{
    public Animator animator;
    public GameObject grassController;
    private grassController grass;

    // Start is called before the first frame update
    void Start()
    {
        grassController = GameObject.FindGameObjectWithTag("grass");
        grass = grassController.GetComponent<grassController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grass.left)
            animator.SetBool("left", true);
        if (!grass.left)
            animator.SetBool("left", false);
        if (grass.right)
            animator.SetBool("right", true);
        if (!grass.right)
            animator.SetBool("right", false);
        if (grass.jump)
            animator.SetBool("jumping", true);
        if (!grass.jump)
            animator.SetBool("jumping", false);

    }
}
