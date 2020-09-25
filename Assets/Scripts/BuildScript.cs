using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScript : MonoBehaviour
{
    public GameObject bluePrintObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SpawnBluePrintObject()
    {
        Instantiate(bluePrintObject);
    }
}
