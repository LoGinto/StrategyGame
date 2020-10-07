using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MovementOfUnits : MonoBehaviour
{
    private Vector3 offset;
    private NavMeshAgent myAgent;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Selected(bool select)
    {       
        if (select)
        {
            //place circle here
            Debug.Log(gameObject.name + " is selected");
        }
    }
    public void MoveToSpot(Vector3 position)
    {
        //movement here
        Vector3 pos = new Vector3(position.x, transform.position.y, position.z);
        Vector3 moveToPos = pos + offset;
        myAgent.SetDestination(moveToPos);        
    }
    public void MoveToSpot(Vector3 _pos, Vector3 _center)
    {
        Vector3 center = new Vector3(_center.x, transform.position.y, _center.z);
        Vector3 pos = new Vector3(_pos.x, transform.position.y, _pos.z);

        offset = center - transform.position;
        Vector3 moveToPos = pos + offset;
        myAgent.SetDestination(moveToPos);
    }

    public void CalculateOffset(Vector3 _center)
    {
        Vector3 center = new Vector3(_center.x, transform.position.y, _center.z);
        offset = center - transform.position;
    }
    

}
