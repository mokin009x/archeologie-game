using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MuseumUIUpdate : MonoBehaviour
{
    public GameObject moneyCounter;
    // Start is called before the first frame update
    void Start()
    {
        moneyCounter.transform.GetComponentInChildren<TextMeshProUGUI>().text = PlayerData.instance.GetCredits().ToString();
    }

    
}
