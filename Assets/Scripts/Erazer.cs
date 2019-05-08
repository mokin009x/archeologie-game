using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erazer : MonoBehaviour
{
    public Touch MainFinger;

    public Vector3 TouchPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TouchPos.x = MainFinger.position.x;
        TouchPos.x = MainFinger.position.y;
    }
}
