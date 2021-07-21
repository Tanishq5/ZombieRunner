using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas ImpactCanvas;
    [SerializeField] float ImpactTime = 0.3f;

    void Start()
    {
        ImpactCanvas.enabled = false;
    }

    public void ShowDamage()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator ShowSplatter()
    {
        ImpactCanvas.enabled = true;
        yield return new WaitForSeconds(ImpactTime);
        ImpactCanvas.enabled = false;
    }
}
