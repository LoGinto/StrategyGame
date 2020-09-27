using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Resources : MonoBehaviour
{
    //resource manager
    [Header("Ints")]
    public int goldResource = 100;
    public int woodResource = 100;
    public int foodResource = 100;
    public int steelResource = 100;
    [Header("UI elements")]
    public Text goldText;
    public Text woodText;
    public Text foodText;
    public Text steelText;
    // Start is called before the first frame update
    void Start()
    {
        goldText = goldText.gameObject.GetComponent<Text>();
        woodText = woodText.gameObject.GetComponent<Text>();
        foodText = foodText.gameObject.GetComponent<Text>();
        steelText = steelText.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = goldResource.ToString();
        woodText.text = woodResource.ToString();
        foodText.text = foodResource.ToString();
        steelText.text = steelResource.ToString();
    }
    public void MinusResource(int id,int amount)
    {
        if(id == 1)
        {
            goldResource -= amount;
        }
        else if (id == 2)
            woodResource -= amount;
        else if (id == 3)
            foodResource -= amount;
        else if (id == 4)
            steelResource -= amount;
        else if (id > 0 || id > 4)
        {
            Debug.Log("Please enter valid ID");
        }
    }
    public int GetResource(int id)
    {
        if (id == 1)
        {
            return goldResource;
        }
        else if (id == 2)
        {
            return woodResource;
        }
        else if (id == 3)
        {
            return foodResource;
        }
        else if (id == 4)
        {
            return steelResource;
        }
        else
        {
            return 0;
        }
    }
}
