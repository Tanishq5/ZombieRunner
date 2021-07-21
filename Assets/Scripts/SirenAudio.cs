using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenAudio : MonoBehaviour
{
    public AudioClip SirenA;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
