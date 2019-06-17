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
    public GameObject[] dirt;
    public GameObject levelClearScreen;

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

        if (transform.position == MoveHere.position)
        {
            levelClearScreen.SetActive(true);
        }
    }
    public void OnTap()
    {
        PlayerPrefs.SetInt("Relic 1",1);
        clicked = true;
    }
}
