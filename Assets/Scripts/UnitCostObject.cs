using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Cost",menuName = "Cost")]
public class UnitCostObject : ScriptableObject
{
    public int archerCost = 7;
    public int knightCost = 8;
    public int magicianCost = 10;
    public int shooterCost = 9;
    public int assasinCost = 12;
    public int farmerGoldCost = 5;
}
