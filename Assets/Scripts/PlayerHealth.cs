using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float PHealth = 100f;
    DeathHandler deathHandler;

    void Start()
    {
        deathHandler = GetComponent<DeathHandler>();
    }

    public void playerDamage(float damage)
    {
        PHealth -= damage;
        if(PHealth <= 0)
        {
            deathHandler.HandleDeath();
        }
    }
}
