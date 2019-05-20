﻿using System.Collections;
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
        
        
            stoneLayer.GetComponent<StoneLayer>().instance.DecreaseHP();
        
            /*if (stoneLayer.GetComponent<StoneLayer>().instance.health <= 0 )
            {
            
                Destroy(stoneLayer);
            }*/
           
            //transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject);
    }
}
    