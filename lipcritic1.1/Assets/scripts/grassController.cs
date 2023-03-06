using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassController : MonoBehaviour
{
    public bool left;
    public bool right;
    public bool jump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void grassleft()
    {
        left = true;
    }
    public void grassright()
    {
        right = true;
    }
    public void grassup()
    {
        jump = true;
    }
    public void grassleftstop()
    {
        left = false;
    }
    public void grassrightstop()
    {
        right = false;
    }
    public void grassjumpstop()
    {
        jump = false;
    }
}
