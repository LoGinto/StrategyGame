using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInteraction : MonoBehaviour
{
    [SerializeField] Material selectingMat;
    Material initMat;
    bool isSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        initMat = GetComponent<Renderer>().sharedMaterial;
    }

    public void ClickedOn()
    {
        gameObject.GetComponent<Renderer>().sharedMaterial = selectingMat;
        isSelected = true;
        Debug.Log(gameObject.name + " is Selected");
    }
    public void NotSelected()
    {
        isSelected = false;
        gameObject.GetComponent<Renderer>().sharedMaterial = initMat;
    }
    public bool GetSelectionState()
    {
        return isSelected;
    }

}
