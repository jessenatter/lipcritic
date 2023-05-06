using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    public GameObject cow;
    private NMEpatrol NMEpatrol;

    private void Start()
    {
        NMEpatrol = cow.GetComponent<NMEpatrol>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" )
        {
            NMEpatrol.wallhit();
        }
    }
}
