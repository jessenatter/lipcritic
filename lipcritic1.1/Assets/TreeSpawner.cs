using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    public GameObject tree;
    private Vector3 Location;
    private Quaternion Rotation;

    // Start is called before the first frame update
    void Start()
    {
        //i being x cord
        for (float i = -20; i < 20; i + Random.Range(3f, 4f))
        {
            //instantiate tree with z rotation between 22 and -22, x pos that is between 3 and 4 units away, and y pos between 2 and 3.5

            //start at x = -20, end at x =20
           Location = new Vector3(i, Random.Range(2f, 3.5f), 1f);
            Rotation = Quaternion.Euler(0, 0, Random.Range(-22f, 22));
           Instantiate(tree, Location, Rotation);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
