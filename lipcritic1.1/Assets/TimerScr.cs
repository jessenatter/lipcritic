using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScr : MonoBehaviour
{

    Image ARMtimer;
    public float maxTime = 5f;
    float timeLeft;
    float speed = 1;
    float timecountup = 0;
    public bool canshoot;
    private enum State
    {
        frozen,
        countdown,
        countup,
    }

    private State state;

    public GameObject balls;
    public projectile projectileV;

    // Start is called before the first frame update
    void Start()
    {
        ARMtimer = GetComponent<Image>();
        timeLeft = maxTime;
        projectileV = balls.GetComponent<projectile>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            default:
            case State.frozen:

                canshoot = true;
                timecountup = 0;

                break;

            case State.countdown:

                if (timeLeft > 0)
                {
                    timeLeft -= Time.deltaTime;
                    ARMtimer.fillAmount = timeLeft / maxTime * speed;
                }
                else
                {
                    timerend();
                }

                break;

            case State.countup:

                ARMtimer.fillAmount = timecountup / 1000f;

                timecountup = timecountup + 1;

                if (ARMtimer.fillAmount == 1f)
                    state = State.frozen;

                break;
        }

        Debug.Log(state);
    }

    private void timerend()
    {
        projectileV.timedone();
        state = State.countup;
    }
    public void startTimer()
    {
        speed = 1;
        timeLeft = maxTime;
        state = State.countdown;
    }
    public void SpeedTimer()
    {
        speed = 0.5f;
    }
    public void TimerReset()
    {

    }
}
