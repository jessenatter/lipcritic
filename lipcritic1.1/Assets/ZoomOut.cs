using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomOut : MonoBehaviour
{
    public CinemachineVirtualCamera CM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetButtonDown("Fire2"))
            zoom();

    }
    
    private void zoom()
    {
       
    }

}
