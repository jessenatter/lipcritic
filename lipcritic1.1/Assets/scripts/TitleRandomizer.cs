using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;


public class TitleRandomizer : MonoBehaviour
{
    public float random;
    public TextMeshProUGUI text;
    public Volume V;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.fontSize = 80f + 5f * (SineAmmount());
        V.weight = (SineAmmount2());
    }

    public float SineAmmount()
    {
        return Mathf.Sin(Time.time * 10f);
    }

    public float SineAmmount2()
    {
        return Mathf.Sin(Time.time);
    }


}

