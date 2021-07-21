using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float addIntensity = 1f;

    private void OnTriggerEnter(Collider trigg)
    {
        if(trigg.gameObject.tag == "Player")
        {
            trigg.GetComponentInChildren<TorchSystem>().RestoreLightAngle(restoreAngle);
            trigg.GetComponentInChildren<TorchSystem>().AddLightIntensity(addIntensity);
            Destroy(gameObject);
        }
    }
}
