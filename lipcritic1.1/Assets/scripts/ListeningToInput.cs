using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ListeningToInput : MonoBehaviour
{
    public TextMeshProUGUI text;

    private bool connected = false;

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

    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckForControllers());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            loadnext();


        if (connected)
        {
            text.text = "PRESS X TO PLAY";

        }
        if (!connected)
        {
            text.text = "PRESS SPACE TO PLAY";
        }
    }

    public void loadnext()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(1f);


        SceneManager.LoadScene(levelIndex);
    }
}
