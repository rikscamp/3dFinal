using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementV4 : MonoBehaviour
{
    private PlayerControls controls;
    private Rigidbody2D rigidB;
    public Transform playerSprite;

    public float moveSpeed;
    public float jumpForce;
    public float groundDashSpeed;
    public float airDashForce;
    public float airDashLift;

    private float lerpVelocityX = 0;
    private float friction = 0.1f;
    private float direction;

    //gravity Value
    private float gravityVal = 7f;

    //crouch
    public bool isCrouch = false;

    public bool isBouncy = false;

    //All of this detects ground
    public bool isGrounded; //bool that determines if the player is grounded
    public Transform groundCheck; //invisible object on players feet that help detect the ground
    public float checkRadius; //radius of above object's detection
    public LayerMask isGround; //checks the layer of object that the player is standing on

    //Timers
    //coyote time
    private float coyoteTime = 0.15f;
    private float coyoteTimeCounter;
    //jump buffer
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    //dash timers
    private float zeroFrictionLockTime;
    private float groundDashTime;

    //Game States 
    public bool airDashControLock = false;
    public bool zeroFriction;
    public bool isSwimming;

    public Vector2 InputVector;


    
    private void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>();
        controls = new PlayerControls();

        direction = 1;

        //Handles movement Input
        controls.Controls.Movement.performed += ctx => InputVector = ctx.ReadValue<Vector2>();
        controls.Controls.Movement.canceled += ctx => InputVector = Vector2.zero;

        controls.Controls.Jump.performed += ctx => Jump();
        controls.Controls.Jump.canceled += ctx => JumpCancelled();

        controls.Controls.Tumble.performed += ctx => Dash();
        controls.Controls.Tumble.canceled += ctx => DashCancelled();

        controls.Controls.Escape.performed += ctx => Quit();

    }

   

    private void Update()
    {
        //Timer Functionality       
        if (groundDashTime > 0) groundDashTime -= Time.deltaTime;
        if (zeroFrictionLockTime > 0) zeroFrictionLockTime -= Time.deltaTime;


        
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move Velocity torwards Ideal Velocity
        rigidB.velocity = new Vector2(Mathf.Lerp(rigidB.velocity.x, lerpVelocityX, friction), rigidB.velocity.y);
              

        //Checks to see if moving
        if (Mathf.Abs(lerpVelocityX) > 0.1f) 
        {
            direction = Mathf.Sign(lerpVelocityX);
            transform.localScale = new Vector3(direction, 1, 1);
        }

        // Gravity
        rigidB.AddForce(Physics.gravity * gravityVal, ForceMode2D.Force);


        //Ground check
        //checks many variables to determine if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, isGround);
        
        //crouch check
        if (InputVector.y < -0.8)
        {
            isCrouch = true;
            Debug.Log("crouching");
        }
        else
        {
            isCrouch = false;
            //Debug.Log("not crouch");
        }

        jumpBufferCounter -= Time.deltaTime;

        //All Ground Checks
        #region Ground Checks

        if (isGrounded)
        {
            //sets coyote time
            coyoteTimeCounter = coyoteTime;


            friction = .5f;
            airDashControLock = false;
            
            if(zeroFrictionLockTime <= 0) zeroFriction = false;
            

        }
        else 
        {
            //counts down coyote time
            coyoteTimeCounter -= Time.deltaTime;


            groundDashTime = 0;

            if (zeroFriction)
            {
                friction = 0;
            }
            else
            {
                friction = 0.1f;
            }
        }
        #endregion

        #region Ground Dash
        //Ground dash
        if (groundDashTime > 0)
        {
            lerpVelocityX = direction * groundDashSpeed;
        }
        else 
        {
            if (!airDashControLock)
            {
                //Ideal Velocity gets set to input Vector * moveSpeed
                lerpVelocityX = InputVector.x * moveSpeed;
            }
        }
        #endregion

    }



    void Dash()
    {
        if (groundDashTime <= 0 && !airDashControLock) 
        {
            if (isGrounded)
            {
                //start Ground Dash
                groundDashTime = 0.4f;
            }
            else
            {
                //Start Air Dash
                airDashControLock = true;
                zeroFriction = true;
                rigidB.velocity = new Vector2(direction * airDashForce, airDashLift);
            }
        }
    }

    void DashCancelled()
    {
        
    }

    void Jump()
    {
        jumpBufferCounter = jumpBufferTime;

        //makes player bounce of things higher. check Ienumerator!
        if (!isGrounded)
        {
            StartCoroutine(BounceMultiplier());
        }
        

        if (coyoteTimeCounter > 0 && jumpBufferCounter > 0)
        {

            Debug.Log("jumped");

            

            if (groundDashTime > 0)
            {
                groundDashTime = 0;
                zeroFriction = true;
                rigidB.velocity = new Vector2(direction * groundDashSpeed * 1.8f, jumpForce * 0.8f);
                zeroFrictionLockTime = .1f;
                jumpBufferCounter = 0f;
            }
            else
            {
                rigidB.velocity = new Vector2(rigidB.velocity.x, jumpForce);
                jumpBufferCounter = 0f;
            }

        }
    }

    void JumpCancelled()
    {
        //if button is let go, jump is cancelled before peak
        if (rigidB.velocity.y > 0) 
            rigidB.velocity = new Vector2(rigidB.velocity.x, rigidB.velocity.y * 0.5f);

        coyoteTimeCounter = 0;
    }


    IEnumerator BounceMultiplier()
    {
        isBouncy = true;
        yield return new WaitForSeconds(.4f);
        isBouncy = false;
    }
   

    void Quit()
    {
        Debug.Log("Quit");

        Application.Quit();

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
