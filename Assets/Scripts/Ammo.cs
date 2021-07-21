using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int TotalAmmo;
    } 

    public int GetTotalAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).TotalAmmo;
    }
    public void reduceAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).TotalAmmo--;
    }

    public void IncreaseAmmo(AmmoType ammoType,int TotalAmmo)
    {
        GetAmmoSlot(ammoType).TotalAmmo += TotalAmmo;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }

}
