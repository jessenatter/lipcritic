using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCover : MonoBehaviour


{

    Image ARMtimer;
    public GameObject realTimer;
    public TimerScr TS;

    // Start is called before the first frame update
    void Start()
    {
        ARMtimer = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        ARMtimer.fillAmount = TS.fillammount / 20f;
    }
}
