using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField]
    public bool clicked;
    public Transform MoveHere;
    [SerializeField]
    float speed;


    private void Start()
    {
        clicked = false;
    }
    private void FixedUpdate()
    {
        if (clicked)
        {
            transform.position = Vector3.MoveTowards(transform.position, MoveHere.position, speed * Time.deltaTime);
        }
    }
    public void OnTap()
    {
        clicked = true;
    }
}
