using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UnitSelection : MonoBehaviour
{
    [SerializeField] Box box;
    [SerializeField] Projector projector;
    [SerializeField] Collider[] selection;
    [SerializeField] LayerMask selectableLayer;//unit layer
    private Vector3 startpos, dragPos;
    Camera cam;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {           
            RaycastHit hit;
            ray = cam.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray,out hit, 100f);
            if (Input.GetMouseButtonDown(1))
            {
                //drag start
                projector.enabled = true;
                startpos = hit.point;
                box.baseMin = startpos;
            }
            //while dragging    
            dragPos = hit.point;
            box.baseMax = dragPos;
            projector.aspectRatio = box.Size.x / box.Size.z;
            projector.orthographicSize = box.Size.z*0.5f;
            projector.transform.position = box.Center;  
        }
        else if (Input.GetMouseButtonUp(1))
        {
            //mouse release
            //also I should deselect but it's easy
            projector.enabled = false;
            selection = Physics.OverlapBox(box.Center,box.Extents,Quaternion.identity,selectableLayer);
            //add it to unit list afterwards    
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(box.Center,box.Size); 
    }
}
[System.Serializable]
public class Box
{   
    public Vector3 baseMin,baseMax;
    public Vector3 Center
    {
        get
        {
            Vector3 center = baseMin + (baseMax-baseMin)*0.5f;
            center.y = (baseMax - baseMin).magnitude * 0.5f;
            return center;
        }
    }
    public Vector3 Size
    {
        get
        {
            return new Vector3(Mathf.Abs(baseMax.x-baseMin.x),(baseMax-baseMin).magnitude,Mathf.Abs(baseMax.z -baseMin.z));
        }
    }
    public Vector3 Extents
    {
        get
        {
            return Size * 0.5f;
        }
    }
}

    
