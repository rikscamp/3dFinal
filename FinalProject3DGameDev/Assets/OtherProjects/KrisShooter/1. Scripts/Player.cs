using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Controls controls;

    private CharacterController characterController;

    private Vector3 velocity;
    private Vector2 move;

    //Shooting Variables
    private Transform muzzle;

    //Holds current camera
    [SerializeField] Camera currentCam;
    [SerializeField] Camera mainCam;          //cam1   //added by tina
    [SerializeField] Camera cam2;
    [SerializeField] Camera cam3;

    //added by tina
    [SerializeField] float rotationFloat;
    [SerializeField] bool spinning;
    public float lerpDuration, timeElapsed;


    //Player variables
    [SerializeField] private float speed = 7f;
    [SerializeField] private float sprintSpeed = 14f;
    [SerializeField] private float originalSpeed = 7f;
    [SerializeField] private float jumpHeight = 3.5f;


    //various player states
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool sprintReleased;

    //checks for Grounded
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    //force of gravity on player
    public float gravity = -9.81f;

    private void Awake()
    {
        controls = new Controls();

        characterController = GetComponent<CharacterController>();
        
        //Jump
        controls.Gameplay.Jump.performed += _ => OnJumpPressed();

        //Sprint    
        controls.Gameplay.Sprint.performed += ctx => Sprint();
        controls.Gameplay.Sprint.canceled += ctx => SprintReleased();

        //Fire
        controls.Gameplay.Fire.performed += ctx => Fire();

        //Gun piece
        //muzzle = GameObject.Find("Muzzle").transform;
        //gun = GameObject.Find("Gun").transform;

        currentCam = mainCam;       //added by Tina

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Grounded Logic
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //Gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        //Movement
        move = controls.Gameplay.Movement.ReadValue<Vector2>();
        Vector3 movement = move.y * transform.forward + (move.x * transform.right);
        characterController.Move(movement * speed * Time.deltaTime);

        //Jump
        if (isJumping && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
        }
        if(isJumping && !isGrounded) {isJumping = false;}



        //added by tina

        if (timeElapsed < lerpDuration)
        {
            transform.rotation = Mathf.Lerp(transform.rotation, rotationFloat, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }

    }

    //controls trigger boxes to change camera
    //added by tina
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("TriggerBox"))
        {
            Debug.Log("triggered");
            rotationFloat = other.gameObject.GetComponent<Rotate>().target;
            Destroy(other.gameObject);
            //transform.Rotate(0.0f, rotationFloat, 0.0f, Space.Self);
        }


        //mainCam.enabled = false;
        //mainCam.transform.SetParent(null);
        //mainCam = other.gameObject.transform.GetChild(0).GetComponent<Camera>();
        //mainCam.transform.SetParent(this.gameObject.transform);
        //mainCam.enabled = true;
        //Destroy(other);



        //if (other.gameObject.CompareTag("Trigger1"))
        //{
        //    currentCam.enabled = false;
        //    currentCam = mainCam;
        //    mainCam.enabled = true;
        //}

        //if (other.gameObject.CompareTag("Trigger2"))
        //{

        //    currentCam.enabled = false;
        //    currentCam = cam2;
        //    cam2.enabled = true;
        //}

        //if (other.gameObject.CompareTag("Trigger3"))
        //{
        //    currentCam.enabled = false;
        //    currentCam = cam3;
        //    cam3.enabled = true;
        //}
    }

    private void Fire()
    {
        /*
        Ray LOS = new Ray(Camera.main.transform.position, Camera.main.transform.rotation * Camera.main.transform.position);
        RaycastHit hit;
        Vector3 target;
        
        if(Physics.Raycast(LOS, out hit, 100f, groundMask)) {
            target = hit.point;
        } else {
            target = muzzle.forward;
        }
        

        Debug.DrawRay(Camera.main.transform.position, target);
        muzzle.LookAt(target);
        */

        
    }

    private void Sprint()
    {
        if (isGrounded)
        {
            speed = sprintSpeed;
        }
        
    }
    private void SprintReleased()
    { 
       
            speed = originalSpeed;
        
        
    }

    public void OnJumpPressed()
    {
        isJumping = true;
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
