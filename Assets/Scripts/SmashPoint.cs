using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashPoint : MonoBehaviour
{
    public GameObject stoneLayer;

    private bool FirstTime;
    // Start is called before the first frame update
    void Start()
    {
        FirstTime = true;
        stoneLayer = gameObject.transform.parent.gameObject;
    }
    public void DestroyThisObject()
    {
        
        
            stoneLayer.GetComponent<StoneLayer>().health = stoneLayer.GetComponent<StoneLayer>().health +- 1;
        
            if (stoneLayer.GetComponent<StoneLayer>().health <= 0)
            {
            
                Destroy(stoneLayer);
            }

            FirstTime = false;
            Destroy(this);

        
        

    }
}
