using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]


public class PlayerController : MonoBehaviour
{
    private Controls controls;

    [SerializeField]
    private float speed;
    private Rigidbody rb;
    private Vector2 inputVector;



    private void Awake()
    {
        controls = new Controls();

        controls.Move.Walk.performed += ctx => inputVector = ctx.ReadValue<Vector2>();
        controls.Move.Walk.canceled += ctx => inputVector = Vector2.zero;

        // controls.Move.Jump.performed += ctx => Jump();
        // controls.Move.Jump.canceled += JumpCanceled();

    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

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