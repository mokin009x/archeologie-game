using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonClick : MonoBehaviour
{
    AudioSource audio;
    public AudioClip clickSound;
    
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void PlayAudio()
    {
        audio.PlayOneShot(clickSound);
    }
}
