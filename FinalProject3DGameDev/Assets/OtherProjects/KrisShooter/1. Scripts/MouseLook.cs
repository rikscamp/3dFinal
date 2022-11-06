using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private Controls controls;

    //controller sensitivity
    [SerializeField] private float sensitivity;

   

  
    //Controller Vector
    private Vector2 look;
    private float xRotation;

   

    private Transform playerBody;

    private void Awake()
    {
        controls = new Controls();

        playerBody = transform.parent;

       
    }

    // Update is called once per frame
    void Update()
    {
        look = controls.Gameplay.Look.ReadValue<Vector2>();

        var JoyX = (look.x * Time.deltaTime) * sensitivity;
        var JoyY = (look.y * Time.deltaTime) * sensitivity;

        xRotation -= JoyY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * JoyX);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       
        
    }

   

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
