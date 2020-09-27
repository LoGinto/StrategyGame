using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public CanvasGroup guiObject;
    bool clickedOnmenu = false;
    // Start is called before the first frame update
    void Start()
    {
        guiObject = GetComponent<CanvasGroup>();
        clickedOnmenu = true;
        TurnOnAndOffBuildingUI();
    }

    public void TurnOnAndOffBuildingUI()
    {
        clickedOnmenu = !clickedOnmenu;
        if (!clickedOnmenu)
        {
            guiObject.alpha = 0f;
            guiObject.blocksRaycasts = false;
            guiObject.interactable = false;
        }
        else
        {
            guiObject.alpha = 1f;
            guiObject.blocksRaycasts = true;
            guiObject.interactable = true;
        }
    }
}
