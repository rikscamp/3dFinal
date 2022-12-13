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

    //determines direction
    private float direction;

    [SerializeField] private Animator animator;

    //added by tina for footsteps
    public AudioSource[] audio;
    

    //added by tina
    [SerializeField] float rotationFloat;
    [SerializeField] bool spinning;
    public float lerpDuration = 2.0f;
    public float timeElapsed;


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

    //Respawning Variables
    public NewRespawn NewRespawn;
    public GameObject PlayerOBJ;


    private void Awake()
    {
        controls = new Controls();

        audio = GetComponents<AudioSource>();

        characterController = GetComponent<CharacterController>();
        
        //Jump
        controls.Gameplay.Jump.performed += _ => OnJumpPressed();

        //Sprint    
        controls.Gameplay.Sprint.performed += ctx => Sprint();
        controls.Gameplay.Sprint.canceled += ctx => SprintReleased();

        //Exits the Game
        controls.Gameplay.Exit.performed += _ => OnExitPressed();

        //Respawning
        controls.Gameplay.Respawn.performed += ctx => Respawn();

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


        ////added by tina to play footsteps
        //if(isGrounded && ((velocity.x != 0) || (velocity.z != 0)))
        //{
        //    audio[0].Play();
        //    audio[1].Play();
        //}

        //Jump
        if (isJumping && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
        }
        if(isJumping && !isGrounded) {isJumping = false;}


        //Sets animator values
        animator.SetFloat("X", movement.x);

        animator.SetFloat("Y", velocity.y);

        animator.SetFloat("Z", movement.z);

        animator.SetBool("isGrounded", isGrounded);

        animator.SetFloat("speed", movement.magnitude);

        //flip
        if(move.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (move.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
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
            transform.Rotate(0.0f, rotationFloat, 0.0f, Space.Self);
        }


        
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

    public void OnExitPressed()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    private void Respawn()
    {
        PlayerOBJ.transform.position = NewRespawn.RespawnPoint;
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
