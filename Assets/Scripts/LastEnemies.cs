using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] Enemies;
    [SerializeField] Enemy_AI EA1;
    [SerializeField] Enemy_AI EA2;
    [SerializeField] Enemy_AI EA3;
    [SerializeField] Enemy_AI EA4;
    [SerializeField] Enemy_AI EA5;
    [SerializeField] Enemy_AI EA6;
    [SerializeField] Enemy_AI EA7;
    [SerializeField] Enemy_AI EA8;
    [SerializeField] Enemy_AI EA9;
    [SerializeField] Enemy_AI EA10;

    public bool SwitchAccess = false;

    void Update()
    {
        EnemiesDeadOrNot();
    }

    private void EnemiesDeadOrNot()
    {
        foreach(GameObject enemy in Enemies)
        {
            if (EA1.enabled == false && EA2.enabled == false && EA3.enabled == false && EA4.enabled == false && EA5.enabled == false 
                && EA6.enabled == false && EA7.enabled == false && EA8.enabled == false && EA9.enabled == false && EA10.enabled == false)
            {
                Debug.Log("All Enemies Dead");
                SwitchAccess = true;
            }
        }
    }
}
