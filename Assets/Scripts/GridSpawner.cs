using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public int Resolution;
    public GameObject blockPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = -160; x < Resolution; x++)
        {
            for (int z = -160; z < Resolution; z++)
            {
                GameObject block = Instantiate(blockPrefab , new Vector3(0 ,0,0 + z) , transform.rotation) as GameObject;

                block.transform.parent = transform;
                block.transform.localPosition = new Vector3(x,0,z);
            }
        }
    }
}
