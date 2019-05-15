using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneLayer : MonoBehaviour
{
    public int health;
    public int amountOfSmashPoints;
    public GameObject smashPointPrefab;
    public GameObject[] smashPoints;

    private void Start()
    {
        health = amountOfSmashPoints;
        smashPoints = new GameObject[amountOfSmashPoints];
        for (int i = 0; i < smashPoints.Length; i++)
        {
            GameObject newSmashpoint = Instantiate(smashPointPrefab,transform.position,Quaternion.identity, gameObject.transform);
            newSmashpoint.transform.localPosition = new Vector3(Random.Range(0, 40), 0.25f, Random.Range(0, 40));
            smashPoints[i] = newSmashpoint;
            
        }
    }
}
