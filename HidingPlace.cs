using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlace : MonoBehaviour
{
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject HidingCam;

    private GameObject playerObj;


    bool isIn;

    float xRotation = 0;
    float yRotation = 0;

    private void Start()
    {
        playerObj = GameObject.Find("PlayerBody");
    }
    private void OnTriggerEnter(Collider other)
    {
        title.SetActive(true);

    }
    private void OnTriggerExit(Collider other)
    {
        title.SetActive(false);

    }
    private void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isIn)
            {
                isIn = true;

                Player.instance.TurnOffFlashLight();
                Player.instance.isCameraMovementActive = false;
                Player.instance.isPlayerMovementActive = false;

                HidingCam.SetActive(true);
                playerObj.SetActive(false);

                
            }
            else
            {
                isIn = false;

                HidingCam.SetActive(false);
                playerObj.SetActive(true);

                Player.instance.isCameraMovementActive = true;
                Player.instance.isPlayerMovementActive = true;

                Player.instance.TurnOnFlashLight();
            }
            StartCoroutine(WaitForSeconds(1f));
        }
    }
    private void FixedUpdate()
    {
        if (HidingCam.active)
        {
            float mouseX = Input.GetAxis("Mouse X") * Player.instance.sensivity * Time.fixedDeltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Player.instance.sensivity * Time.fixedDeltaTime;



            xRotation -= mouseY;
            yRotation -= mouseX;
            xRotation = Mathf.Clamp(xRotation, -30f, 30f);
            yRotation = Mathf.Clamp(yRotation, -30f, 30f);


            HidingCam.transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);
            // HidingCam.transform.Rotate(Vector3.up * yRotation);
        }
    }

    private IEnumerator WaitForSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
