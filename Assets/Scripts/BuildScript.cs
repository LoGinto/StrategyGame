using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScript : MonoBehaviour
{
    public GameObject bluePrintObject;
    public int woodCost = 30;
    public int goldCost = 6;
    public Resources resources;
    // Start is called before the first frame update
    void Start()
    {
        resources = resources.gameObject.GetComponent<Resources>();
    }
    public void SpawnBluePrintObject()
    {
        if (resources.GetResource(1)>=goldCost && resources.GetResource(2)>=woodCost)
        {
            Instantiate(bluePrintObject);
        }
        else
        {
            Debug.Log("Not enough resources");
        }
    }
}
