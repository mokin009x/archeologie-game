using System;
using System.Collections;
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
    public string selectedTool;
    public float duration;

    public GameObject timerObj;
    public bool gameOver;
    public GameObject gameOverScreen;

    private void Awake()
    {
        gameOver = false;
    }

    private void Start()
    {
        selectedTool = "None";
        //counter= GameObject.Find("Canvas").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();

        pikLevel = PlayerData.instance.GetPikhouweelLevel();
        SchepLevel = PlayerData.instance.GetSchepLevel();
        StartCoroutine(LevelTimer());
    }

    IEnumerator LevelTimer()
    {
        //to whatever you want
        do
        {
            string time = Mathf.RoundToInt(duration -= Time.deltaTime).ToString();
            timerObj.transform.GetComponentInChildren<TextMeshProUGUI>().text =  time;
            //Debug.Log(timer);
            if (PlayerData.instance.currentLevelClear == true)
            {
                PlayerData.instance.currentLevelClear = false;
                yield break;
            }
            yield return null;
        } while (duration >= 0);
        gameOver = true;
        
    }

    void Update()
    {
        

        TouchInputCheck();
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            counter.text = PlayerData.instance.GetCredits().ToString();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectedTool = "Pikhouweel";
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            selectedTool = "Schep";
        }

        if (gameOver == true)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void TouchInputCheck()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began && selectedTool == "Pikhouweel")
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
            if (Input.GetTouch(i).phase == TouchPhase.Moved && selectedTool == "Schep")
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
            
            if (Input.GetTouch(i).phase == TouchPhase.Began && selectedTool == "Schep")
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;

                // Create a particle if hit
                Physics.Raycast(ray, out hit, Mathf.Infinity);
                if (hit.collider.CompareTag("Relic"))
                {
                    hit.collider.GetComponent<Artifact>().OnTap();
                    PlayerData.instance.AddCredits(200);
                }
            }
        }
    }

    public void SelectTool(string tool)
    {
        selectedTool = tool;
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