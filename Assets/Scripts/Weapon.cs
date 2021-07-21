using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPcamera;
    [SerializeField] float Range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem MuzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo AmmoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float WaitingTime = 0.5f;
    [SerializeField] TextMeshProUGUI AmmoText;

    bool CanShoot = true;

    private void OnEnable()
    {
        CanShoot = true;
    }

    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButtonDown(0) && CanShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    public void DisplayAmmo()
    {
        int CurrentAmmo = AmmoSlot.GetTotalAmmo(ammoType);
        AmmoText.text = CurrentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        CanShoot = false;
        if (AmmoSlot.GetTotalAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            AmmoSlot.reduceAmmo(ammoType);
        }
        yield return new WaitForSeconds(WaitingTime);
        CanShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        MuzzleFlash.Play();
    }
    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPcamera.transform.position, FPcamera.transform.forward, out hit, Range))
        {
            CreateHitEffect(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
            {
                return;
            }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitEffect(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
