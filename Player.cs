using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float speed;
    public float sensivity;
    public float crouchSpeed;
    public float runSpeed;
    public bool isCameraMovementActive = true;
    public bool isPlayerMovementActive = true;


    private CharacterController character;
    [Header("Grawitacja")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float gravity;

    private Vector3 velocity;
    [Header("Latarka")]
    public bool hasFlashlight = false;

    [SerializeField] private GameObject FlashLight;
    public bool isFlashlightOn = false;
    [SerializeField] private PlayableDirector flashlightOFF;
    [SerializeField] private PlayableDirector flashlightON;


    //
    float xRotation = 0f;
    [Header("Ró¿ne")]
    public CinemachineVirtualCamera cam;

    private void Awake()
    {
        instance = this;
        character = GetComponent<CharacterController>();
        cam = GetComponentInChildren<CinemachineVirtualCamera>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && hasFlashlight)
        {
            if (isFlashlightOn)
            {
                isFlashlightOn = false;
                flashlightOFF.Play();

            } else
            {
                isFlashlightOn= true;
                flashlightON.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        if (isActiveAndEnabled)
        {


            FlashLight.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        // Player Movement
        float xPlayerAxis = Input.GetAxis("Horizontal");
        float yPlayerAxis = Input.GetAxis("Vertical");

        if (isPlayerMovementActive )
        {
            Vector3 move = transform.right * xPlayerAxis * speed * Time.fixedDeltaTime + transform.forward * yPlayerAxis * speed * Time.fixedDeltaTime;
            character.Move(move);
        }
        velocity.y += gravity * Time.fixedDeltaTime;
        character.Move(velocity);
    }
    public void TurnOnFlashLight()
    {
        if (!isFlashlightOn && hasFlashlight)
        {
            isFlashlightOn = true;
            flashlightON.Play();
        }
    }

    public void TurnOffFlashLight()
    {
        if (isFlashlightOn && hasFlashlight)
        {
            isFlashlightOn = false;
            flashlightOFF.Play();
        }
    }

}
