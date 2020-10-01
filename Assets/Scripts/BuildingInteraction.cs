using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInteraction : MonoBehaviour
{
    [SerializeField] Material selectingMat;
    Material initMat;
    // Start is called before the first frame update
    void Start()
    {
        initMat = GetComponent<Renderer>().sharedMaterial;
    }

    public void ClickedOn()
    {
        gameObject.GetComponent<Renderer>().sharedMaterial = selectingMat;
        Debug.Log(gameObject.name + " is Selected");
    }
    public void NotSelected()
    {
        gameObject.GetComponent<Renderer>().sharedMaterial = initMat;
    }

}
