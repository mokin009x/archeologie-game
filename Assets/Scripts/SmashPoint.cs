using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashPoint : MonoBehaviour
{
    public GameObject stoneLayer;
    int damage;
    // Start is called before the first frame update
    void Start()
    {
        stoneLayer = gameObject.transform.parent.gameObject;
    }
    public void DestroyThisObject()
    {
        stoneLayer.GetComponent<StoneLayer>().health =- damage;
        if (stoneLayer.GetComponent<StoneLayer>().health <= 0)
        {
            Destroy(stoneLayer);
        }
        Destroy(this);

    }
}
