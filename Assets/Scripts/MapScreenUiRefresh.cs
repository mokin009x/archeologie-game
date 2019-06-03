using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapScreenUiRefresh : MonoBehaviour
{
    public GameObject money;
    // Start is called before the first frame update
    void Start()
    {
        money.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PlayerData.instance.GetCredits().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
