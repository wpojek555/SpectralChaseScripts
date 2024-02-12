using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightItem : MonoBehaviour
{
    [SerializeField] private GameObject equipUI;
    [SerializeField] private GameObject flashlight;
    private void OnTriggerEnter(Collider other)
    {
        equipUI.SetActive(true);

    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Player.instance.hasFlashlight = true;
            Player.instance.TurnOnFlashLight();
            flashlight.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        equipUI.SetActive(false);
    }
}
