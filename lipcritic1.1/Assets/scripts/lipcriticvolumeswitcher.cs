using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class lipcriticvolumeswitcher : MonoBehaviour
{
    public Volume meemo;
    public void switchw()
        {
        meemo.weight = 1f;
        }
public void switchBack()
{
        meemo.weight = 0f;
}
}
