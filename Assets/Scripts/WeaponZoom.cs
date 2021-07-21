using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpscamera;
    [SerializeField] RigidbodyFirstPersonController fpscontroller;

    [SerializeField] float ZoomIn = 25f;
    [SerializeField] float ZoomOut = 60f;
    [SerializeField] float ZoomInSens = 0.7f;
    [SerializeField] float ZoomOutSens = 1.5f;

    bool ZoomInToggle = false;

    private void OnDisable()
    {
        zoomOut();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(ZoomInToggle == false)
            {
                zoomIn();
            }
            else
            {
                zoomOut();
            }
        }
    }

    public void zoomIn()
    {
        ZoomInToggle = true;
        fpscamera.fieldOfView = ZoomIn;
        fpscontroller.mouseLook.XSensitivity = ZoomInSens;
        fpscontroller.mouseLook.YSensitivity = ZoomInSens;
    }
    public void zoomOut()
    {
        ZoomInToggle = false;
        fpscamera.fieldOfView = ZoomOut;
        fpscontroller.mouseLook.XSensitivity = ZoomOutSens;
        fpscontroller.mouseLook.YSensitivity = ZoomOutSens;
    }
}
