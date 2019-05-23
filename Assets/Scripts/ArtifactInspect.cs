using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArtifactInspect : MonoBehaviour
{
    public GameObject examinePosition;
    public bool examineMode;
    public GameObject pickupObj;
    public List<GameObject> pickupableObjects;

    public int speed;
    public Vector3 originalPosition;
    public Vector3 originalRotation;

    private void Start()
    {
        //pickupableObjects = new List<GameObject>();
        examineMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        ClickObject();

        IsClicked();

        //ExitExamineMode();
       // Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red);
    }

    void ClickObject()
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
                    for (int j = 0; j < pickupableObjects.Count; j++) 
                    {
                        if(hit.collider.gameObject == pickupableObjects[j]) 
                        {
                                pickupObj = pickupableObjects[j];
                                originalPosition = pickupObj.gameObject.transform.position;
                                originalRotation = pickupObj.gameObject.transform.rotation.eulerAngles;
                                //originalPosition = pickupObj.transform.position;
                        
                                pickupObj.transform.position = Vector3.MoveTowards(pickupObj.transform.position, examinePosition.transform.position , speed * Time.deltaTime );
                                //pickupObj.transform.position = examinePosition.transform.position;

                                //Time.timeScale = 0;

                                examineMode = true;
                        }
                    }
                }
            } 
        }
    }

    void IsClicked()
    {
        if(examineMode == true)
        {
            float rotateSpeed = 3f;

            float xAxis = Input.GetAxis("Mouse X") * rotateSpeed;
            float yAxis = Input.GetAxis("Mouse Y") * rotateSpeed;

            pickupObj.transform.Rotate(Vector3.up, -xAxis, Space.World);
            pickupObj.transform.Rotate(Vector3.right, yAxis, Space.World);
        }
    }

    public void ExitExamineMode()
    {
       
            pickupObj.transform.position = originalPosition;
            pickupObj.transform.eulerAngles = originalRotation;
            examineMode = false;
    }
}
