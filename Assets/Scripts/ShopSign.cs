using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopSign : MonoBehaviour
{
    public GameObject signOn;
    public GameObject signOff;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SwitchSign());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SwitchSign()
    {
        do
        {
            yield return new WaitForSeconds(1f);
            if (signOff.gameObject.activeSelf == true)
            {
                signOff.SetActive(false);
                signOn.SetActive(true);
            }
            else
            {
                signOff.SetActive(true);
                signOn.SetActive(false); 
            }  
        } while (SceneManager.GetActiveScene().name == "Shop" );
    }
}
