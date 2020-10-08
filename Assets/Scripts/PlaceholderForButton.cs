using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderForButton : MonoBehaviour
{
    SelectionCasst selection;
    // Start is called before the first frame update
    void Start()
    {
        selection = Camera.main.GetComponent<SelectionCasst>();
    }

    public void ClickEventSpawn()
    {
        if (selection.GetSelectedObject().GetComponent<HouseFunctionality>())
        {
            selection.GetSelectedObject().GetComponent<HouseFunctionality>().Spawn();
        }
        else if (selection.GetSelectedObject().GetComponent<WarUnitSpawn>())
        {
            selection.GetSelectedObject().GetComponent<WarUnitSpawn>().Spawn();
        }
    }
}
