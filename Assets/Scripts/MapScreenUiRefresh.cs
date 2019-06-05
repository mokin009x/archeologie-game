using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapScreenUiRefresh : MonoBehaviour
{
    public GameObject money;
    public int progression;
    

    // Start is called before the first frame update
    void Start()
    {
        
        money.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PlayerData.instance.GetCredits().ToString();
        if (OnSceneLoadScript.CheckActiveScene("Map Screen"))
        {
            progression = PlayerData.instance.GetMapProgression();
        }
        
        Debug.Log(progression);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}