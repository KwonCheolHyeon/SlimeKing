using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip BackGroundSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlaySound("BackGroundSound");
    }
    void PlaySound(string action)
    {
        switch (action)
        {
            
            case "BackGroundSound":
                audioSource.clip = BackGroundSound;
                break;
            

        }
        audioSource.Play();
    }
}
