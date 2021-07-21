using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Radio : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] AudioClip radio;
    [SerializeField] TextMeshProUGUI RadioInteract;
    [SerializeField] float distance;

    AudioSource audioSource;

    bool radioff;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        RadioInteract.enabled = false;
    }

    void Update()
    {
        distance = Vector3.Distance(Player.position, transform.position);

        if(distance <= 13)
        {
            if (!audioSource.isPlaying && radioff == false)
            {
                audioSource.PlayOneShot(radio);
            }
        }

        if(distance > 13)
        {
            audioSource.Stop();
        }

        if(distance < 1.5f)
        {
            RadioInteract.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                radioff = true;
                audioSource.Stop();
            }
        }
        else
        {
            RadioInteract.enabled = false;
        }
    }
}
