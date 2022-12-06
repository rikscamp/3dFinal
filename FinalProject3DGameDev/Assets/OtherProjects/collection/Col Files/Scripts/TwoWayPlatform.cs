using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TwoWayPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;

    private PlayerControls controls;

    public Vector2 move;
    // Start is called before the first frame update
    void Awake()
    {
        effector = GetComponent<PlatformEffector2D>();
        controls = new PlayerControls();

        controls.Controls.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Controls.Movement.canceled += ctx => move = Vector2.zero;

        
    }

    // Update is called once per frame
    void Update()
    {

        

        if(move.y== -1.0f)
        {
            effector.rotationalOffset = 180f;
        }
        if (move.y == 0)
        {
            effector.rotationalOffset = 0;
        }

       
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
