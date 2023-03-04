using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    public GameObject tree;
    private Vector3 Location;
    private Quaternion Rotation;
    public GameObject MapStart;
    public GameObject MapEnd;

    private float Mstart;
    private float Mend;
    private float TreeNumb;

    private float xpos;
    // Start is called before the first frame update
    void Start()
    {
        Mstart = MapStart.transform.position.x;
        Mend = MapEnd.transform.position.x;

        //number of trees will be deternimed by the distance between the map start and end, devided by 4, because distance bewteen each tree is between 3 and 4 

        TreeNumb = (Mathf.Abs(Mend) + Mathf.Abs(Mstart)) / 3;

        //i being x cord
        for (float i = 1; i < TreeNumb; i++)
        {
            xpos = Mstart + i * Random.Range(2f, 3f);
            //instantiate tree with z rotation between 22 and -22, x pos that is between 3 and 4 units away, and y pos between 2 and 3.5
           Location = new Vector3(xpos, 2f, Random.Range(5f,10f));
           Rotation = Quaternion.Euler(0, 0, Random.Range(-22, 22));
           Instantiate(tree, Location, Rotation);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
