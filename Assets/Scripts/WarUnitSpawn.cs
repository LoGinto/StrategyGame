using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WarUnitSpawn : MonoBehaviour
{
    [SerializeField] GameObject unitToSpawn;
    Transform spawnAt;
    [SerializeField] float spawnTime;
    [SerializeField] UnitCostObject unitCost;
    CanvasGroup unitSpawnCanvasGroup;
    BuildingInteraction building;
    bool queue = false;
    int archerCost;
    int knightCost;
    int magicianCost;
    int shooterCost;
    int assasinCost;
    Resources resources;
    SelectionCasst selection;
    Text archerCostText;
    Text knightCostText;
    Text magicianCostText;
    Text shooterCostText;
    Text assasinCostText;
    public enum Warrior{
        
           archer,knight,magician,shooter,assasin
        }
    public Warrior warrior;
    private void Start()
    {
        FindTagsInStart();
        selection = Camera.main.GetComponent<SelectionCasst>();
        AssignCostText();
    }

    private void AssignCostText()
    {
        archerCost = unitCost.archerCost;
        knightCost = unitCost.knightCost;
        magicianCost = unitCost.magicianCost;
        shooterCost = unitCost.shooterCost;
        assasinCost = unitCost.assasinCost;
        archerCostText.text = archerCost.ToString();
        knightCostText.text = knightCost.ToString();
        assasinCostText.text = assasinCost.ToString();
        magicianCostText.text = magicianCost.ToString();
        shooterCostText.text = shooterCost.ToString();
    }

    private void FindTagsInStart()
    {
        archerCostText = GameObject.FindGameObjectWithTag("ArcherRecruitmentText").GetComponent<Text>();
        assasinCostText = GameObject.FindGameObjectWithTag("AssasinRecruitmentText").GetComponent<Text>();
        magicianCostText = GameObject.FindGameObjectWithTag("MagicianRecruitmentText").GetComponent<Text>();
        shooterCostText = GameObject.FindGameObjectWithTag("ShooterRecruitmentText").GetComponent<Text>();
        knightCostText = GameObject.FindGameObjectWithTag("KnightRecruitmentText").GetComponent<Text>();
        unitSpawnCanvasGroup = GameObject.FindGameObjectWithTag("RecruitingCanvas").GetComponent<CanvasGroup>();
        resources = GameObject.FindGameObjectWithTag("RM").GetComponent<Resources>();
    }

    public void Spawn()
    {        //button function
        if (queue == false)
        {
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
            queue = true;
            StartCoroutine(SpawnTheUnit());            
        }
        else
        {
            Debug.Log("Queue " + queue);
        }
    }
    private void FixedUpdate()
    {
        ToggleUI();      
        if (selection.GetSelectedObject() != null)
        {
            building = selection.GetSelectedObject().GetComponent<BuildingInteraction>();
            spawnAt = selection.GetSelectedObject().transform.Find("SpawnAt");
        }
        else
        {
            return;
        }

    }
    void ToggleUI()
    {
        try
        {
            if (building != null && selection.GetSelectedObject().GetComponent<RecruitmentCenterEmptyScript>() && selection.GetSelectedObject() != null)
            {
                if (unitSpawnCanvasGroup.alpha == 1f)
                {
                    unitSpawnCanvasGroup.blocksRaycasts = true;
                }
                if (building.GetSelectionState() == true && selection.GetSelectedObject().GetComponent<RecruitmentCenterEmptyScript>())
                {
                    unitSpawnCanvasGroup.alpha = 1f;
                    unitSpawnCanvasGroup.blocksRaycasts = true;
                    unitSpawnCanvasGroup.interactable = true;
                }
                else
                {
                    unitSpawnCanvasGroup.alpha = 0f;
                    unitSpawnCanvasGroup.blocksRaycasts = false;
                    unitSpawnCanvasGroup.interactable = false;
                }
            }
            else
            {
                unitSpawnCanvasGroup.alpha = 0f;
                unitSpawnCanvasGroup.blocksRaycasts = false;
                unitSpawnCanvasGroup.interactable = false;
            }
        }
        catch
        {
            unitSpawnCanvasGroup.alpha = 0f;
            unitSpawnCanvasGroup.blocksRaycasts = false;
            unitSpawnCanvasGroup.interactable = false;
        }
        
        }
    public void CloseButton()
    {
        try
        {
            building.NotSelected();
        }
        catch
        {
            Debug.Log("Catch in close executed");
            unitSpawnCanvasGroup.alpha = 0f;
            unitSpawnCanvasGroup.blocksRaycasts = false;
            unitSpawnCanvasGroup.interactable = false;
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
