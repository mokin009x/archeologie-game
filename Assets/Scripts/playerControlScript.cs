﻿using System;
using System.Collections;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Collections;

public class playerControlScript : MonoBehaviour
{
    private Vector3 position;
    private float width;
    private float height;
    public GameObject particle;
    public GameObject dragParticle;
    public RaycastHit dragHit;
   // public GameObject hitCube;


    private void Start()
    { 
      //  hitCube = GameObject.Find("Cube");
//        hitCube.gameObject.SetActive(false);
    }

   

    void OnGUI()
    {
       
    }

    void Update()
    {
        
    
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;
                

                // Create a particle if hit
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag("Smash Point"))
                    {
                        hit.collider.GetComponent<SmashPoint>().DestroyThisObject();
                    }

                    if (hit.collider.CompareTag("Relic"))
                    {
                        hit.collider.GetComponent<Artifact>().OnTap();
                    }
                }
            }
            if (Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;
                

                // Create a particle if hit
                Physics.Raycast(ray, out hit, Mathf.Infinity);

                if (hit.collider.gameObject.CompareTag("Dirt"))
                {
                    Destroy(hit.collider.gameObject);
                }
                
            }
            
        }
    

       
        /*// Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(-pos.x, pos.y, 0.0f);

                // Position the cube.
                transform.position = new Vector3(-position.x * 150, 0, position.y * 150);
            }

          
        }*/

        
        
        /*

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                // Create a particle if hit
                if (Physics.Raycast(ray))
                {
                    Instantiate(particle, transform.position, transform.rotation);
                }
            }
        }
*/

    }
}