using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour
{
    public int tileX;
    public int tileY;
    public TIleMap map;
    private void OnMouseUp()
    {
        Debug.Log("Click");
        map.MoveUnitTo(tileX, tileY);
    }
}
