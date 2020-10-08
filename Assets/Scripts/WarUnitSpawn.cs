using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarUnitSpawn : MonoBehaviour
{
    [SerializeField] GameObject unitToSpawn;
    [SerializeField] Transform spawnAt;
    [SerializeField] float spawnTime;
    [SerializeField] UnitCostObject unitCost;
    bool queue = false;
    int archerCost;
    int knightCost;
    int magicianCost;
    int shooterCost;
    int assasinCost;
    Resources resources;
    public enum Warrior{
        
           archer,knight,magician,shooter,assasin
        }
    public Warrior warrior;
    private void Start()
    {
        archerCost = unitCost.archerCost;
        knightCost = unitCost.knightCost;
        magicianCost = unitCost.magicianCost;
        shooterCost = unitCost.shooterCost;
        assasinCost = unitCost.assasinCost;
        resources = GameObject.FindGameObjectWithTag("RM").GetComponent<Resources>();
    }
    public void Spawn()
    {        
        if (queue == false)
        {
            queue = true;
            if (warrior == Warrior.archer)
            {
                if (resources.GetResource(1) >= archerCost)
                {
                    resources.MinusResource(1, archerCost);
                }
            }
            else if (warrior == Warrior.knight)
            {
                if (resources.GetResource(1) >= knightCost)
                {
                    resources.MinusResource(1, knightCost);
                }
            }
            else if (warrior == Warrior.magician)
            {
                if (resources.GetResource(1) > magicianCost)
                {
                    resources.MinusResource(1, magicianCost);
                }
            }
            else if (warrior == Warrior.shooter)
            {
                if (resources.GetResource(1) >= shooterCost)
                {
                    resources.MinusResource(1, shooterCost);
                }
            }
            else if (warrior == Warrior.assasin)
            {
                if (resources.GetResource(1) >= assasinCost)
                {
                    resources.MinusResource(1, assasinCost);
                }
            }
            StartCoroutine(SpawnTheUnit());            
        }
        else
        {
            Debug.Log("Queue " + queue);
        }
    }
    IEnumerator SpawnTheUnit()
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(unitToSpawn, spawnAt.position, Quaternion.identity);
        Debug.Log("spawned at " + spawnAt.position + " Gold: " + resources.GetResource(1) + "Food:" + resources.GetResource(3));
        queue = false;
    }
}
