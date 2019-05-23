using System;
using System.Collections;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Collections;
using UnityEngine.SceneManagement;

public class playerControlScript : MonoBehaviour
{
    private Vector3 position;
    private float width;
    private float height;
    public GameObject particle;
    public GameObject dragParticle;
    public RaycastHit dragHit;
    public TextMeshProUGUI counter;

    private int toolLevel;
   // public GameObject hitCube;


    private void Start()
    {
        counter= GameObject.Find("Canvas").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        if (PlayerData.instance.GetCurrentSceneName() == "Level 1")
        {
            toolLevel = PlayerData.instance.GetToolLevel();
        }
    }

   

    

    void Update()
    {
        TouchInputCheck();
        LevelCheat();
        if (SceneManager.GetActiveScene().name == "Level 1")
        { 
            
            counter.text = PlayerData.instance.GetCredits().ToString();
        }
    }

    public void TouchInputCheck()
    {
        
        for (int i = 0; i < Input.touchCount; ++i)
        {
            
            //pickaxe
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;
                

                // Create a particle if hit
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag("Smash Point"))
                    {
                        hit.collider.GetComponent<SmashPoint>().DestroyThisObject();
                        ToolEffectMoneyIncrease();
                    }

                    if (hit.collider.CompareTag("Relic"))
                    {
                        hit.collider.GetComponent<Artifact>().OnTap();
                    }
                }
            }
            
            //Shovel
            if (Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;
                

                // Create a particle if hit
                Physics.Raycast(ray, out hit, Mathf.Infinity);

                if (hit.collider.gameObject.CompareTag("Dirt"))
                {
                    Destroy(hit.collider.gameObject);
                }
                
            }
            
        }
    }


    void LevelCheat()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerData.instance.toolLevel = 1;
            toolLevel = PlayerData.instance.toolLevel;
        }
    }

    public void ToolEffectMoneyIncrease()
    {
        
            PlayerData.instance.AddCredits(10 * toolLevel);
        
    }
}