using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerMovementV4 playerMove;
    private Animator animator;

    private int currentState;

    //AnimationStates
    int Player_Idle;
    int Player_Walk;
    int Player_Jump;
    int Player_IdleToCrouch;
    int Player_Crouch;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        playerMove = transform.parent.GetComponent<PlayerMovementV4>();

        Player_Idle = Animator.StringToHash("Tumblin_Idle");
        Player_Walk = Animator.StringToHash("Tumblin_Walk");
        Player_Jump = Animator.StringToHash("Tumblin_ToJump");
        Player_IdleToCrouch = Animator.StringToHash("Tumblin_IdleToSit");
        Player_Crouch = Animator.StringToHash("Tumblin_Sit");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerMove.isGrounded)
        {

            if (playerMove.InputVector.y < -0.8f)
            {
                ChangeAnimationState(Player_IdleToCrouch);
            }
            else 
            {
                if (Mathf.Abs(playerMove.InputVector.x) > 0.1f)
                {
                    ChangeAnimationState(Player_Walk);
                }

                else
                {
                    ChangeAnimationState(Player_Idle);
                }
            }
        }          
        else
        {
            ChangeAnimationState(Player_Jump);
        }

       

    }

    void ChangeAnimationState(int newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play the animation
        animator.Play(newState);

        //reassign the current state
        currentState = newState;
    }
}
