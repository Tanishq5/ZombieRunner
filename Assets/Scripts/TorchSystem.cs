using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSystem : MonoBehaviour
{
    [SerializeField] float LightFading = 0.1f;
    [SerializeField] float AngleFading = 1f;
    [SerializeField] float MinAngle = 40f;

    Light MyLight;
    void Start()
    {
        MyLight = GetComponent<Light>();
    }

    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        MyLight.spotAngle = restoreAngle;
    }

    public void AddLightIntensity(float addIntensity)
    {
        MyLight.intensity += addIntensity;
    }

    public void DecreaseLightAngle()
    {
        if(MyLight.spotAngle <= MinAngle)
        {
            return;
        }
        else
        {
            MyLight.spotAngle -= AngleFading * Time.deltaTime;
        }
    }

    public void DecreaseLightIntensity()
    {
        MyLight.intensity -= LightFading * Time.deltaTime;
    }
}
