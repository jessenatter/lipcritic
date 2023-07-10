using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class autoZoomOut : MonoBehaviour
{
    public CinemachineVirtualCamera CM;
    public GameObject player;
    public PlayerMovement pm;
    public float realFOV;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerMovement>();
        realFOV = 68f;
    }

    // Update is called once per frame
    void Update()
    {
        CM.m_Lens.FieldOfView = realFOV;

        if (Mathf.Abs(pm.horizontalMove) > 0)
        {
            if(realFOV < 90f)
             realFOV += 10f * (Time.deltaTime);
        }
        else
        {
            if(realFOV > 60f)
            realFOV -= 30f * (Time.deltaTime);
        }

    }
}
