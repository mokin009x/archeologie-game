using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    public int credits;
    public int pikhouweelLevel;
    public int schepLevel;
    public int startPrice;
    public int mapProgression;
    public string currentScene;
    public bool currentLevelClear;
    public bool[] relicCollection = new bool[6];

    
    public void Awake()
    {
        currentLevelClear = false;
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
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        CheckPlayerPrefs();
    }

    

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddCredits(100);
            Debug.Log(credits);
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.SetInt("Credits", credits);
            PlayerPrefs.Save();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            mapProgression ++;
            PlayerPrefs.SetInt("MapProgression", mapProgression);
        }
        
        if (Input.GetKeyDown(KeyCode.N))
        {
            mapProgression --;
            PlayerPrefs.SetInt("MapProgression", mapProgression);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayerPrefs.SetInt("Relic 1",1);
            PlayerPrefs.SetInt("Relic 3",1);
            PlayerPrefs.SetInt("Relic 5",1);
            PlayerPrefs.Save();
        }
        

        if (Input.GetKeyDown(KeyCode.K)) credits = PlayerPrefs.GetInt("Credits");
        
    }
    
    public void CheckPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Credits"))
        {
            credits = PlayerPrefs.GetInt("Credits");
        }
        else
        {
            PlayerPrefs.SetInt("Credits", credits);
            credits = PlayerPrefs.GetInt("Credits");
        }

        if (PlayerPrefs.HasKey("PikhouweelLevel"))
        {
            pikhouweelLevel = PlayerPrefs.GetInt("PikhouweelLevel");
        }
        else
        {
            PlayerPrefs.SetInt("PikhouweelLevel", 1);
            pikhouweelLevel = PlayerPrefs.GetInt("PikhouweelLevel");
        }

        if (PlayerPrefs.HasKey("SchepLevel"))
        {
            schepLevel = PlayerPrefs.GetInt("SchepLevel");
        }
        else
        {
            PlayerPrefs.SetInt("SchepLevel", 1);
            schepLevel = PlayerPrefs.GetInt("SchepLevel");
        }

        if (PlayerPrefs.HasKey("StartPrice"))
        {
            startPrice = PlayerPrefs.GetInt("StartPrice");
        }
        else
        {
            PlayerPrefs.SetInt("StartPrice", 125);
            startPrice = PlayerPrefs.GetInt("StartPrice");
        }

        if (PlayerPrefs.HasKey("MapProgression"))
        {
            mapProgression = PlayerPrefs.GetInt("MapProgression");
        }
        else
        {
            PlayerPrefs.SetInt("MapProgression", 1);
            mapProgression = PlayerPrefs.GetInt("MapProgression");
        }
    }

    public void CheckCollectedRelics()
    {
        if (PlayerPrefs.HasKey("Kandelaar"))
        {
            if (PlayerPrefs.GetInt("Kandelaar") == 1)
            {
                relicCollection[0] = true;
            }
            else
            {
                PlayerPrefs.SetInt("Kandelaar", 0);
                relicCollection[0] = false;
            }
        }

        if (PlayerPrefs.HasKey("Spaarpot"))
        {
            if (PlayerPrefs.GetInt("Spaarpot") == 1)
            {
                relicCollection[1] = true;
            }
            else
            {
                PlayerPrefs.SetInt("Spaarpot", 0);
                relicCollection[1] = false;
            }
        }

        if (PlayerPrefs.HasKey("Lavabo"))
        {
            if (PlayerPrefs.GetInt("Lavabo") == 1)
            {
                relicCollection[2] = true;
            }
            else
            {
                PlayerPrefs.SetInt("Lavabo", 0);
                relicCollection[2] = false;
            }
        }

        if (PlayerPrefs.HasKey("Relic 4"))
        {
            if (PlayerPrefs.GetInt("Relic 4") == 1)
            {
                relicCollection[3] = true;
            }
            else
            {
                PlayerPrefs.SetInt("Relic 4", 0);
                relicCollection[3] = false;
            }
        }

        if (PlayerPrefs.HasKey("Relic 5"))
        {
            if (PlayerPrefs.GetInt("Relic 5") == 1)
            {
                relicCollection[4] = true;
            }
            else
            {
                PlayerPrefs.SetInt("Relic 5", 0);
                relicCollection[4] = false;
            }
        }

        if (PlayerPrefs.HasKey("Relic 6"))
        {
            if (PlayerPrefs.GetInt("Relic 6") == 1)
            {
                relicCollection[5] = true;
            }
            else
            {
                PlayerPrefs.SetInt("Relic 6", 0);
                relicCollection[5] = false;
            }
        }
    }

    public void AddCredits(int amount)
    {
        credits += amount;
        PlayerPrefs.SetInt("Credits", credits);
    }

    public void DecreaseCredits(int amount)
    {
        credits -= amount;
        PlayerPrefs.SetInt("Credits", credits);
    }

    public int GetCredits()
    {
        return credits;
    }

    public int GetPikhouweelLevel()
    {
        return pikhouweelLevel;
    }
    
    public int GetSchepLevel()
    {
        return schepLevel;
    }

    public string GetCurrentSceneName()
    {
        currentScene = SceneManager.GetActiveScene().name;
        return currentScene;
    }

    public int GetStartPrice()
    {
        return startPrice;
    }

    public int GetMapProgression()
    {
        return mapProgression;
    }
}