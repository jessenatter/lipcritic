using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goAway : MonoBehaviour
{
    private float timecountup;
    public Image image;
    private float alpha = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timecountup += Time.deltaTime * 10;

        if (timecountup >= 5f)
            gameObject.SetActive(false);

        alpha = 5 - timecountup / 5f;
        

        image.color = new Color(1f, 1f, 1f, alpha);
        
    }

    public void timecountupstart()
    {
        timecountup = 0;
        image.color = new Color(1f, 1f, 1f, 1f);
    }
}
