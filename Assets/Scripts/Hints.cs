using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hints : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI zHintText;
    [SerializeField] TextMeshProUGUI DialogueText;
    [SerializeField] TextMeshProUGUI WarningText;
    [SerializeField] TextMeshProUGUI EnemyHintText;
    [SerializeField] Canvas GameOver2;
    [SerializeField] Radio R;
    [SerializeField] SirenAudio SA;
    [SerializeField] GameObject Siren;
    [SerializeField] float t;
    [SerializeField] int DialogueTextOnlyOnce = 0;
    [SerializeField] int WarningTextOnlyOnce = 0;
    [SerializeField] int EnemyHintTextOnlyOnce = 0;


    [SerializeField] AudioSource audioSource;
    void Start()
    {
        zHintText.enabled = true;
        DialogueText.enabled = false;
        WarningText.enabled = false;
        EnemyHintText.enabled = false;
        GameOver2.enabled = false;
    }
    void Update()
    {
        DisableZHint();
        DisableDialogueText();
        DisableEnemyHintText();
    }

    private void DisableZHint()
    {
        float perFrame = t * Time.time;
        t++;

        if (t >= 250)
        {
            zHintText.enabled = false;
        }
    }

    private void DisableDialogueText()
    {
        if (t >= 250)
        {
            DialogueText.enabled = false;
        }
    }
    private void DisableEnemyHintText()
    {
        if (t >= 250)
        {
            EnemyHintText.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider trigg)
    {
        if(trigg.gameObject.tag == "DTrigger" && DialogueTextOnlyOnce == 0)
        {
            DialogueTextOnlyOnce = 1;
            t = 0;
            DialogueText.enabled = true;
        }

        if(trigg.gameObject.tag == "WT" && WarningTextOnlyOnce == 0)
        {
            WarningTextOnlyOnce = 1;
            WarningText.enabled = true;

            Siren.gameObject.SetActive(true);
            audioSource.PlayOneShot(SA.SirenA);
        }
        if(trigg.gameObject.tag == "HT" && EnemyHintTextOnlyOnce == 0)
        {
            EnemyHintTextOnlyOnce = 1;
            t = 0;
            EnemyHintText.enabled = true;
        }
        if(trigg.gameObject.tag == "GameOver")
        {
            Invoke("GameOver", 2f);
        }
    }
    private void GameOver()
    {
        GameOver2.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponChanger>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
