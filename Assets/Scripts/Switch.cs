using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Switch : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] TextMeshProUGUI SwitchInteract;
    [SerializeField] TextMeshProUGUI WarningText;
    [SerializeField] GameObject Door;
    [SerializeField] GameObject Siren;
    [SerializeField] SirenAudio SA;
    [SerializeField] AudioClip Switch1;

    [SerializeField] float distance;

    AudioSource audioSource;
    void Start()
    {
        SwitchInteract.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        distance = Vector3.Distance(Player.position, transform.position);

        if(distance <= 2)
        {
            SwitchInteract.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Door.gameObject.SetActive(false);
                WarningText.enabled = false;
                Siren.gameObject.SetActive(false);
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(Switch1);
                }
            }
        }
        else
        {
            SwitchInteract.enabled = false;
        }
    }
}
