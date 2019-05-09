using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    public GameObject Prefab;
    public Vector3 Startpos;
    public int GridSize;
    public Vector3 StepSize;
    // Start is called before the first frame update

    private void Awake()
    {
        StepSize = new Vector3(0,1,0);
        GridSize = 100;
        Startpos = new Vector3(0,0,0);
    }

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                   
                    Instantiate(Prefab, new Vector3(Startpos.x +j, 0, Startpos.z +i), Quaternion.identity);
                }
            }  
        }  
    }
}
