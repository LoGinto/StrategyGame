using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScript : MonoBehaviour
{
    public GameObject bluePrintObject;
    public int woodCost = 30;
    public int goldCost = 6;
    public Resources resources;
    SelectionCasst cast;
    // Start is called before the first frame update
    void Start()
    {
        resources = resources.gameObject.GetComponent<Resources>();
        cast = GameObject.FindObjectOfType<SelectionCasst>();
    }
    public void SpawnBluePrintObject()
    {
        if (resources.GetResource(1)>=goldCost && resources.GetResource(2)>=woodCost)
        {
            Instantiate(bluePrintObject);
            cast.SetCanSelect(false);
        }
        else
        {
            Debug.Log("Not enough resources");
        }
    }
}
