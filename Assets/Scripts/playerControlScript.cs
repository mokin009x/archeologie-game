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

    private int pikLevel;
    private int SchepLevel;
/*
    public float
*/
   // public GameObject hitCube;


    private void Start()
    {
        //counter= GameObject.Find("Canvas").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        if (OnSceneLoadScript.CheckActiveScene("Level 1") == true )
        {
            pikLevel = PlayerData.instance.GetPikhouweelLevel();
            SchepLevel = PlayerData.instance.GetSchepLevel();
        }

        StartCoroutine(LevelTimer());
    }

    IEnumerator LevelTimer()
    {
        float duration = 3f; // 3 seconds you can change this 
        //to whatever you want
        float timer = 0;
        while(timer <= duration)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            yield return null;
        }
        Debug.Log("Timer done");
    }

    void Update()
    {
        TouchInputCheck();
        if (SceneManager.GetActiveScene().name == "Level 1")
        { 
            
            counter.text = PlayerData.instance.GetCredits().ToString();
        }
    }

    public void TouchInputCheck()
    {
        
        for (int i = 0; i < Input.touchCount; ++i)
        {
            
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
                        PikToolEffectMoneyIncrease(pikLevel);
                    }

                    if (hit.collider.CompareTag("Relic"))
                    {
                        hit.collider.GetComponent<Artifact>().OnTap();
                        PlayerData.instance.AddCredits(200);
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
                    ShovelToolEffectMoneyIncrease(SchepLevel);
                }
                
            }
            
        }
    }
    
    public void PikToolEffectMoneyIncrease(int pikLvl)
    {
        if (pikLvl > 1)
        {
            PlayerData.instance.AddCredits(10 * pikLvl);

        }
    }

    public void ShovelToolEffectMoneyIncrease(int SchepLvl)
    {
        if (SchepLvl > 1)
        {
            PlayerData.instance.AddCredits(1 * SchepLvl);
        }
    }
}