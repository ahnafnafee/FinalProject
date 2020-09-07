using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartScript : MonoBehaviour
{
    public Rigidbody rb;
    public EnemyScript enemy;
    public Renderer bodyPartRenderer;
    public GameObject bodyPartPrefab;
    public bool replaced;

    [Space]
    [Header("Adjacent Body Parts")]
    public GameObject Hip;
    public GameObject LeftUpLeg;
    public GameObject LeftLeg;
    public GameObject RightUpLeg;
    public GameObject RightLeg;
    public GameObject Spine1;
    public GameObject LeftArm;
    public GameObject LeftForeArm;
    public GameObject RightArm;
    public GameObject RightForeArm;
    public GameObject Head;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void HidePartAndReplace()
    {
        Hip.tag = "Dead";
        LeftUpLeg.tag = "Dead";
        LeftLeg.tag = "Dead";
        RightUpLeg.tag = "Dead";
        RightLeg.tag = "Dead";
        Spine1.tag = "Dead";
        LeftArm.tag = "Dead";
        LeftForeArm.tag = "Dead";
        RightArm.tag = "Dead";
        RightForeArm.tag = "Dead";
        Head.tag = "Dead";
        
        
        if (replaced)
            return;

        if(bodyPartRenderer!=null)
            bodyPartRenderer.enabled = false;

        GameObject part = new GameObject();
        if (bodyPartPrefab !=null)
            part = Instantiate(bodyPartPrefab, transform.position, transform.rotation);

        Rigidbody[] rbs = part.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody r in rbs)
        {
            r.interpolation = RigidbodyInterpolation.Interpolate;
            r.AddExplosionForce(15, transform.position, 5);
        }

        rb.AddExplosionForce(15, transform.position, 5);

        this.enabled = false;
        replaced = true;
    }
}
