using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Switch2 : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] TextMeshProUGUI Switch2Interact;
    [SerializeField] GameObject DisableYellow;
    [SerializeField] GameObject EnableGreen;
    [SerializeField] GameObject Door2;
    [SerializeField] AudioClip Switch;
    [SerializeField] LastEnemies LE;

    AudioSource audioSource;

    [SerializeField] float Distance;
    [SerializeField] int S2 = 0;

    void Start()
    {
        EnableGreen.SetActive(false);
        Switch2Interact.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        Distance = Vector3.Distance(Player.position, transform.position);

        if (Distance <= 2 && S2 == 0 && LE.SwitchAccess == true)
        {
            Switch2Interact.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                S2 = 1;
                DisableYellow.gameObject.SetActive(false);
                EnableGreen.gameObject.SetActive(true);
                Door2.gameObject.SetActive(false);

                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(Switch);
                }
            }
        }
        else
        {
            Switch2Interact.enabled = false;
        }
    }
}