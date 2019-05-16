using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashPoint : MonoBehaviour
{
    public GameObject stoneLayer;

    // Start is called before the first frame update
    void Start()
    {
        stoneLayer = gameObject.transform.parent.gameObject;
    }
    public void DestroyThisObject()
    {
        
        
            stoneLayer.GetComponent<StoneLayer>().health = stoneLayer.GetComponent<StoneLayer>().health +- 1;
        
            if (stoneLayer.GetComponent<StoneLayer>().health <= 0)
            {
            
                Destroy(stoneLayer);
            }
            else
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }

            Destroy(this);
    }
}
