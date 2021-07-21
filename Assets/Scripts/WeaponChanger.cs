using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] int CurrentWeapon = 0;

    void Start()
    {
        ChangeWeapon();
    }

    void Update()
    {
        int PreviousWeapon = CurrentWeapon;

        ChangeWeaponByKey();
        ChangeWeaponByScroll();

        if (PreviousWeapon != CurrentWeapon)
        {
            ChangeWeapon();
        }
    }

    public void ChangeWeaponByKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentWeapon = 2;
        }
    }

    public void ChangeWeaponByScroll()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(CurrentWeapon >= 2)
            {
                CurrentWeapon = 0;
            }
            else
            {
                CurrentWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (CurrentWeapon <= 0)
            {
                CurrentWeapon = 2;
            }
            else
            {
                CurrentWeapon--;
            }
        }
    }

    public void ChangeWeapon()
    {
        int weaponIndex = 0;

        foreach(Transform weapon in transform)
        {
            if (weaponIndex == CurrentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
