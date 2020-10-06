using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfUnits : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

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
    public void MoveUnit(Vector3 position)
    {
        //movement here
        Debug.Log(gameObject.name + " should move to " + position);
    }

}
