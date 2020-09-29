using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_Col : MonoBehaviour
{
    public Transform centerOfRadius;
    public float radius = 4f;
    Placement_BluePrint bluePrint;
    public Material redTransparent;
    public Material whiteTransparent;
    Renderer rend;
    private void Start()
    {
        bluePrint = GetComponent<Placement_BluePrint>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
    private void Update()
    {
        Collider[] overlapArray = Physics.OverlapSphere(centerOfRadius.position,radius);
        foreach(Collider collider in overlapArray)
        {
            if(collider.tag == "Building")
            {
                bluePrint.SetCanSpawn(false);
                rend.sharedMaterial = redTransparent;
                
            }
            else
            {
                bluePrint.SetCanSpawn(true);
                rend.sharedMaterial = whiteTransparent;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(centerOfRadius.position, radius);
    }
}
