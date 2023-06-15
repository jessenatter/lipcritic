using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TitleRandomizer : MonoBehaviour
{
    public float random;
    public TextMeshProUGUI text;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.fontSize = 80f + 5f * (SineAmmount());
    }

    public float SineAmmount()
    {
        return Mathf.Sin(Time.time * 10f);
    }
}

