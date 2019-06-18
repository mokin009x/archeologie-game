using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            PlayerPrefs.SetInt("Kandelaar",1);
            

        }
        
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            PlayerPrefs.SetInt("Spaarpot",1);

        }
        PlayerPrefs.Save();
        clicked = true;
    }
}
    