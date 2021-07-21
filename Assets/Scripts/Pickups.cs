using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] int TotalAmmo = 10;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseAmmo(ammoType, TotalAmmo);
            Destroy(gameObject);
        }
    }
}
