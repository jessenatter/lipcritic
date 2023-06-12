using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScr : MonoBehaviour
{

    Image ARMtimer;
    public bool canshoot;
    private float speed = 1f;

    private enum State
    {
        frozen,
        countdown,
        countup,
    }

    private State state;

    public GameObject balls;
    public projectile projectileV;

    public float fillammount;

    // Start is called before the first frame update
    void Start()
    {
        fillammount = 20f;
        ARMtimer = GetComponent<Image>();
        projectileV = balls.GetComponent<projectile>();
        state = State.countup;
    }

    // Update is called once per frame
    void Update()
    { 
        
        ARMtimer.fillAmount = fillammount / 20f;

        if (fillammount >= 10f)
        {
            canshoot = true;
        }
        else
        {
            canshoot = false;
        }

        if (fillammount <= 0)
        {
            ranout();
        }

        switch (state)
        {
            default:

            case State.countdown:

                if (fillammount > 0)
                {
                    if (projectileV.state == projectile.State.normal)
                    {
                        speed = 3f;
                    }
                    else
                    {
                        speed = 6f;
                    }

                    fillammount -= Time.deltaTime * speed;
                }
                else
                {
                    SwitchToCountUp();
                }
                

                break;

            case State.countup:

                if (fillammount < 20f)
                {
                    fillammount += Time.deltaTime * 2f;
                }


                break;
        }
    }

    public void SwitchToCountUp()
    {
        state = State.countup;
    }

    public void SwitchToCountDown()
    {
        state = State.countdown;
    }

    public void boost()
    {
        fillammount += 3f;
    }
    public void ranout()
    {
        projectileV.timedone();
        state = State.countup;
    }
}
