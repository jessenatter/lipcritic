using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tout3 : MonoBehaviour
{
    public Text text;

    private bool connected = false;
    private float alpha;
    private bool fading;

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
        }

        if (connected)
        {
            text.text = "Use the left trigger to zoom out.";

        }
        if (!connected)
        {
            text.text = "Use the right mouse button to zoom out.";
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
