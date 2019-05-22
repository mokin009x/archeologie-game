using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class StoneLayer : MonoBehaviour
{
    public int health;
    public int amountOfSmashPoints;
    public GameObject smashPointPrefab;
    public GameObject[] smashPoints;
    public GameObject canvasObj;
    public int nullCount;
    public bool[] counterCheck;

    public StoneLayer instance;
    private bool hpDebug;


    private void Awake()
    {
        nullCount = 1;
        instance = this;
    }

    private void Start()
    {
        canvasObj = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        health = amountOfSmashPoints;
        smashPoints = new GameObject[amountOfSmashPoints];
        counterCheck = new bool[health];
        for (int i = 0; i < smashPoints.Length; i++)
        {
            GameObject newSmashpoint = Instantiate(smashPointPrefab,transform.position,Quaternion.identity, gameObject.transform);
            newSmashpoint.transform.localPosition = new Vector3(Random.Range(0, 23f), 0.4f, Random.Range(0, 23f));
            smashPoints[i] = newSmashpoint;
        }
    }
    public void DecreaseHP()
    {
        for (int i = 0; i < smashPoints.Length; i++)
        {
            if (smashPoints[i] == null)
            {
                if (counterCheck[i] == false)
                {
                    nullCount ++;
                    counterCheck[i] = true;
                }
            }
        }

        if (nullCount == health)
        {
            Destroy(gameObject);
        }
    }


}
