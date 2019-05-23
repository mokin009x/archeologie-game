using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private int currentCredits;
    private int currentToolLevel;
    
    // Start is called before the first frame update
    void Start()
    {
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
        if (currentToolLevel <= 0)
        {
            if (currentCredits >= price)
            {
                PlayerData.instance.DecreaseCredits(price);
                PlayerData.instance.toolLevel = 1;
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
    }
}
