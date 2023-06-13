using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tout2 : MonoBehaviour
{
    public Text text;

    private bool connected = false;
    private float alpha;
    private bool fading;

    public GameObject tout2;

    public GameObject player;

    public PlayerMovement pm;


    IEnumerator CheckForControllers()
    {
        while (true)
        {
            var controllers = Input.GetJoystickNames();

            if (!connected && controllers.Length > 0)
            {
                connected = true;

            }
            else if (connected && controllers.Length == 0)
            {
                connected = false;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    void Awake()
    {
        StartCoroutine(CheckForControllers());
        alpha = 1f;
        fading = false;
        text.color = new Color(1f, 1f, 1f, 1f);
    }

    private void Update()
    {
        if (fading)
        {
            if (alpha > 0)

            {
                text.color = new Color(1f, 1f, 1f, alpha);
                alpha -= Time.deltaTime;
            }

            if (alpha <= 0)
            {
                tout2.SetActive(true);
            }
        }

        if (pm.state == PlayerMovement.State.player)
        {
            if (connected)
            {
                text.text = "Use the right trigger to activate your magic orb. Wherever your magic orb hits, you teleport to.";

            }
            if (!connected)
            {
                text.text = "Use the left mouse button to activate your magic orb. Wherever your magic orb hits, you teleport to.";
            }
        }
        else
        {
           text.text = "Use your movement inputs to control the magic orb. Wherever your magic orb hits, you teleport to.";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        fadeout();
    }

    private void fadeout()
    {
        text.color = new Color(1f, 1f, 1f, alpha);
        fading = true;
    }
}
