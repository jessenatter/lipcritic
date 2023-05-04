using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LipCriticFLASH : MonoBehaviour
{
    private void Start()
    {
        SP.color = new Color(0, 0, 0, 0);
    }
    public SpriteRenderer SP;

    public void color()
    {
        SP.color = new Color(1,1,1,1);
    }

    public void stop()
    {
        SP.color = new Color(0, 0, 0, 0);
    }
}
