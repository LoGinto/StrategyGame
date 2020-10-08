using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextAndPreviousButtons : MonoBehaviour
{
    [SerializeField] CanvasGroup civilianCanvasGroup;
    [SerializeField] CanvasGroup militaryCanvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        civilianCanvasGroup = civilianCanvasGroup.gameObject.GetComponent<CanvasGroup>();
        militaryCanvasGroup =  militaryCanvasGroup.gameObject.GetComponent<CanvasGroup>();
    }

    public void Next()
    {
        civilianCanvasGroup.alpha = 0f;
        civilianCanvasGroup.blocksRaycasts = false;
        civilianCanvasGroup.interactable =  false;
        //military
        militaryCanvasGroup.alpha = 1f;
        militaryCanvasGroup.blocksRaycasts = true;
        militaryCanvasGroup.interactable = true;
    }
    public void Previous()
    {
        civilianCanvasGroup.alpha = 1f;
        civilianCanvasGroup.blocksRaycasts = true;
        civilianCanvasGroup.interactable = true;
        //military
        militaryCanvasGroup.alpha = 0f;
        militaryCanvasGroup.blocksRaycasts = false;
        militaryCanvasGroup.interactable =   false;

    }
}
