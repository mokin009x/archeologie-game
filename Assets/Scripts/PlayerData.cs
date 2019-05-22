using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int credits;
    public static PlayerData instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddCredits(100);
            Debug.Log(credits);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
           DecreaseCredits(50); 
           Debug.Log(credits);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.SetInt("Credits",credits);
            PlayerPrefs.Save();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            credits = PlayerPrefs.GetInt("Credits");
        }
    }

    public void AddCredits(int amount)
    {
        credits += amount;
    }

    public void DecreaseCredits(int amount)
    {
        credits -= amount;
    }
}
