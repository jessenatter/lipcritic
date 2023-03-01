using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimSCR : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetpos;
    public GameObject bullet;
    public Transform bullettrans;

    private float timeBTW;
    public float startTimeBTW;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        timeBTW = startTimeBTW;
    }

    // Update is called once per frame
    void Update()
    {
        targetpos = target.transform.position;

        Vector3 rotation = targetpos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (timeBTW <= 0)
        {
            Instantiate(bullet, bullettrans.position, Quaternion.identity);
            timeBTW = startTimeBTW;
            Debug.Log(rotZ);
        }
        else
        {
            timeBTW -= Time.deltaTime;
        }
    }
}
