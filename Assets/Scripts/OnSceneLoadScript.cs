using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSceneLoadScript : MonoBehaviour
{
    

    
    public static bool CheckActiveScene(string currentScene)
    {
        if (currentScene == "Level 1")
        {
            return true;
        }

        if (currentScene == "Map Screen")
        {
            return true;
        }

        if (currentScene == "Museum")
        {
            PlayerData.instance.CheckCollectedRelics();
            return true;
        }
        
        return false;
    }
}
