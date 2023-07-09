using UnityEngine;

public class Child : MonoBehaviour
{
    public GameObject P;
    public Transform Parent;//Remember to assign the parent transform 
    private Vector3 pos, fw, up;
    public projectile Pp;
    public ParticleSystem PS;

    void Start()
    {
        P = GameObject.FindGameObjectWithTag("ray");
        Parent = P.transform;
        Pp = P.GetComponent<projectile>();

        pos = Parent.transform.InverseTransformPoint(transform.position);
        fw = Parent.transform.InverseTransformDirection(transform.forward);
        up = Parent.transform.InverseTransformDirection(transform.up);
    }
    void Update()
    {
        if (Pp.pwork == false)
        {
            var main = PS.main;
            main.loop = false;

            //stop emmiting i guess?
            var main2 = PS.emission;
            main2.rateOverTime = 0f;
        }

        var newpos = Parent.transform.TransformPoint(pos);
        var newfw = Parent.transform.TransformDirection(fw);
        var newup = Parent.transform.TransformDirection(up);
        var newrot = Quaternion.LookRotation(newfw, newup);
        transform.position = newpos;
        transform.rotation = newrot;
    }

}