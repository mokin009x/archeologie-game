using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    public int credits;

    
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
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddCredits(100);
            Debug.Log(credits);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            BuyUpgrade(50);
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

    public void BuyUpgrade(int amount)
    {
        credits -= amount;
    }

    public int GetCredits()
    {
        return credits;
    }
}