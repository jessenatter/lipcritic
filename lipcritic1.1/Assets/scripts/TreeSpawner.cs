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
    private float zposget;
    private float zposfinal;

    List<float> zPosGotten = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        Mstart = MapStart.transform.position.x;
        Mend = MapEnd.transform.position.x;

        TreeNumb = (Mathf.Abs(Mend) + Mathf.Abs(Mstart)) / 2;

        //i being x cord
        for (float i = 1; i < TreeNumb; i++)
        {

           zposget = Random.Range(5f, 15f);
           xpos = Mstart + i * Random.Range(1f, 2f);

           while(zPosGotten.Contains(zposget))
           {
                zposget = Random.Range(5f, 15f);
           }

           zposfinal = zposget;

           Location = new Vector3(xpos, 2f, zposfinal);
           Rotation = Quaternion.Euler(0, 0, Random.Range(-22, 22));
           Instantiate(tree, Location, Rotation);
           zPosGotten.Add(zposfinal);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
