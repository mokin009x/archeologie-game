using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    private int currentCredits;
    private int currentPikhouweelLevel;
    private int currentSchepLevel;
    public GameObject moneyCounter;
    public GameObject pikhouweelCounter;
    public GameObject pikhouweelPrice;
    public GameObject schepCounter;
    public GameObject schepPrice;

    // Start is called before the first frame update
    void Start()
    {
      
        moneyCounter.GetComponentInChildren<TextMeshProUGUI>().text = PlayerData.instance.GetCredits().ToString();
        pikhouweelCounter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Level " + PlayerData.instance.GetPikhouweelLevel().ToString();
        
        schepCounter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Level " + PlayerData.instance.GetSchepLevel().ToString();

        if (PlayerData.instance.GetStartPrice() < 125)
        {
            pikhouweelPrice.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "125";
            schepPrice.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "125";
        }
        else
        {
            var price = 125 * PlayerData.instance.GetPikhouweelLevel();
            var price2 = 125 * PlayerData.instance.GetSchepLevel();
            pikhouweelPrice.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Prijs " + price.ToString();
            schepPrice.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Prijs " + price2.ToString();
        }
        /*currentToolLevel = 1;
        currentCredits = 0;*/
        // dit moeten we miss uitcommenten 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PikhouweelUpgrade(int price)
    {
        currentCredits = PlayerData.instance.GetCredits();
        currentPikhouweelLevel = PlayerData.instance.GetPikhouweelLevel();
        
        if (currentPikhouweelLevel <= Mathf.Infinity)
        {
            if (currentCredits >= price * PlayerData.instance.GetPikhouweelLevel())
            {
                PlayerData.instance.DecreaseCredits(price * PlayerData.instance.GetPikhouweelLevel());
                PlayerData.instance.pikhouweelLevel ++;
                currentPikhouweelLevel = PlayerData.instance.pikhouweelLevel;
                PlayerPrefs.SetInt("PikhouweelLevel", currentPikhouweelLevel);
                PlayerPrefs.Save();
            }
        }
        
        var newPrice = price * PlayerData.instance.GetPikhouweelLevel();

        ShopUiUpdate(pikhouweelCounter, currentPikhouweelLevel, newPrice, pikhouweelPrice);
    }

    public void SchepUpgrade(int price)
    {
        currentCredits = PlayerData.instance.GetCredits();
        currentSchepLevel = PlayerData.instance.GetSchepLevel();
        
        if (currentSchepLevel <= Mathf.Infinity)
        {
            if (currentCredits >= price * PlayerData.instance.GetSchepLevel())
            {
                PlayerData.instance.DecreaseCredits(price * PlayerData.instance.GetSchepLevel());
                PlayerData.instance.schepLevel ++;
                currentSchepLevel = PlayerData.instance.schepLevel;
                PlayerPrefs.SetInt("SchepLevel", currentSchepLevel);
                PlayerPrefs.Save();
            }
        }
        
        var newPrice = price * PlayerData.instance.GetSchepLevel();
        
        ShopUiUpdate(schepCounter, currentSchepLevel, newPrice, schepPrice);
    }


    public void ShopUiUpdate(GameObject levelBox, int newToolLevel, int newPrice, GameObject priceCounter)
    {
        moneyCounter.GetComponentInChildren<TextMeshProUGUI>().text = PlayerData.instance.GetCredits().ToString();
        priceCounter.GetComponentInChildren<TextMeshProUGUI>().text = "Prijs " + newPrice.ToString();
        levelBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Level " + newToolLevel.ToString();
        
    }

}
