using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    public int credits;
    public int toolLevel;

    
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

        credits = 0;
        toolLevel = 0;
    }

    // Start is called before the first frame update
    private void Start()
    {
        if (PlayerPrefs.HasKey("Credits"))
        {
            credits = PlayerPrefs.GetInt("Credits");
        }
        else
        {
            PlayerPrefs.SetInt("Credits", credits);
        }

        if (PlayerPrefs.HasKey("ToolLevel"))
        {
            toolLevel = PlayerPrefs.GetInt("ToolLevel");
        }
        else
        {
            PlayerPrefs.SetInt("ToolLevel", toolLevel);
        }
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

        if (Input.GetKeyDown(KeyCode.K)) credits = PlayerPrefs.GetInt("Credits");
    }

    public void AddCredits(int amount)
    {
        credits += amount;
    }

    public void DecreaseCredits(int amount)
    {
        credits -= amount;
    }

    public int GetCredits()
    {
        return credits;
    }

    public int GetToolLevel()
    {
        return toolLevel;
    }

    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}