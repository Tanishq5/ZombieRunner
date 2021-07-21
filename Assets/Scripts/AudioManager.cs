using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip BackgroundSound;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(BackgroundSound);
    }
    void Update()
    {
        
    }
}
