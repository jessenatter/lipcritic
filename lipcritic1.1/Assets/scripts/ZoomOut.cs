using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomOut : MonoBehaviour
{
    public CinemachineVirtualCamera CM;
    private bool meem = false;

    // Start is called before the first frame update
    void Start()
    {
        CM.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            meem = true;
        }
        if(Input.GetButtonUp("Fire2"))
        {
            meem = false;
        }

        if(meem == true)
        {
            if (CM.m_Lens.FieldOfView < 87f)
            {
                CM.m_Lens.FieldOfView += 16f * Time.deltaTime;
            }
        }
        else if (CM.m_Lens.FieldOfView >= 68)
        {
            CM.m_Lens.FieldOfView -= 26f * Time.deltaTime;
        }

    }

 

}
