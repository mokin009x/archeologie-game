using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private int currentCredits;
    private int currentToolLevel;
    public GameObject moneyCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        moneyCounter.GetComponent<TextMeshProUGUI>().text = PlayerData.instance.GetCredits().ToString();
        currentToolLevel = 0;
        currentCredits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TapUpgrade(int price)
    {
        currentCredits = PlayerData.instance.GetCredits();
        currentToolLevel = PlayerData.instance.GetToolLevel();
        if (currentToolLevel <= Mathf.Infinity)
        {
            if (currentCredits >= price)
            {
                PlayerData.instance.DecreaseCredits(price);
                PlayerData.instance.toolLevel ++;
                currentToolLevel = PlayerData.instance.toolLevel;
            }
            else
            {
                Debug.Log(price + " upgrade price" + currentCredits + " amount of credits that you have");
            } 
        }
        else
        {
            Debug.Log("You already have this upgrade");
        }
        
        Debug.Log(PlayerData.instance.toolLevel + " tool level");
        moneyCounter.GetComponent<TextMeshProUGUI>().text = PlayerData.instance.GetCredits().ToString();

    }
    
}
