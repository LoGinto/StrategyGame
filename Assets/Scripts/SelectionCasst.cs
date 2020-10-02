using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCasst : MonoBehaviour
{
    [SerializeField] GameObject selectedObj;
    [SerializeField] LayerMask clickableLayer;
    // Start is called before the first frame update
    bool canSelect;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {           
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, clickableLayer))
            {
                if (canSelect == true)
                {
                    if (selectedObj != null)
                    {
                        selectedObj.GetComponent<BuildingInteraction>().NotSelected();
                        selectedObj = null;
                    }
                    selectedObj = hit.collider.gameObject;
                    selectedObj.GetComponent<BuildingInteraction>().ClickedOn();
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            selectedObj.GetComponent<BuildingInteraction>().NotSelected();
            selectedObj = null;
        }
    }
    public void SetCanSelect(bool value)
    {
        canSelect = value;
    }
    public bool GetCanSelect()
    {
        return canSelect;
    }
    public GameObject GetSelectedObject()
    {
        return selectedObj;
    }
}
