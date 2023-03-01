using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    [Range(0f,1.5f)]

    public float duration = 1f;
    bool _isfrozen = false;
    float _pendindgfreeze = 0f;
    private GameObject player;
    private PlayerMovement Pscript;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Pscript = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(_pendindgfreeze > 0 && !_isfrozen)
        {
            StartCoroutine(DOhitstop());
        }
    }

    public void hitstop()
    {
        _pendindgfreeze = duration;
    }

    IEnumerator DOhitstop()
    {
        _isfrozen = true;
        var original = Time.timeScale;
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = original;
        Pscript.resumecolor();
        _pendindgfreeze = 0f;
        _isfrozen = false;
    }
}
