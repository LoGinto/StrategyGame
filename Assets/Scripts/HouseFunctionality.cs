using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HouseFunctionality : MonoBehaviour
{
    //[SerializeField]Transform spawnTransform;
    //[SerializeField] GameObject unitToSpawn;
    [SerializeField] int coinCost = 5;
    [SerializeField] int foodCost = 2;
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] Transform spawnAt;
    [SerializeField] float timeToWaitBeforeSpawn = 5f;
    private Text goldCostText;
    private Text foodCostText;
    private CanvasGroup unitSpawnCanvasGroup;
    BuildingInteraction building;
    Resources resources;
    SelectionCasst selection;
    // Start is called before the first frame update
    void Start()
    {
        selection = Camera.main.GetComponent<SelectionCasst>();
        unitSpawnCanvasGroup = GameObject.FindGameObjectWithTag("HouseCanvasGroup").GetComponent<CanvasGroup>();
        goldCostText = GameObject.FindGameObjectWithTag("HouseCanvasFoodText").GetComponent<Text>();
        foodCostText = GameObject.FindGameObjectWithTag("HouseCanvasGoldText").GetComponent<Text>();
        resources = GameObject.FindGameObjectWithTag("RM").GetComponent<Resources>();
    }

    private void Update()
    {
        ToggleUI();
        goldCostText.text = coinCost.ToString();
        foodCostText.text = foodCost.ToString();
    }
    private void FixedUpdate()
    {
        if (selection.GetSelectedObject() != null)
        {
            building = selection.GetSelectedObject().GetComponent<BuildingInteraction>();
        }
    }
    private void ToggleUI()
    {
        if (building != null)
        {
            if (building.GetSelectionState() == true)
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
    public void Spawn()
    {
        if (resources.GetResource(1) >= coinCost && resources.GetResource(3) >= foodCost)
        {
            StartCoroutine(SpawnCoroutine());
        }
        else
        {
            Debug.Log("Not enough resources to spawn");
        }
    }
   IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(timeToWaitBeforeSpawn);
        resources.MinusResource(1, coinCost);
        resources.MinusResource(3, foodCost);
        Instantiate(objectToSpawn, spawnAt.position, Quaternion.identity);
        Debug.Log("spawned at " + spawnAt.position + " Gold: " + resources.GetResource(1) + "Food:" + resources.GetResource(3));
    }
}
