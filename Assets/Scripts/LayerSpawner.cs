using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSpawner : MonoBehaviour
{
    public GameObject[] layers;
    public int holeDepth;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < holeDepth; i++)
        {
            GameObject tempLayer = Instantiate(layers[Random.Range(0, layers.Length)]);
            tempLayer.transform.localPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y- i*1.5f, gameObject.transform.position.z);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
