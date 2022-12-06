using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    PlayerMovementV4 playermovement;  

    [SerializeField] private float bounceHigh = 40f;
    [SerializeField] private float bounce = 20;

    private void Awake()
    {
        
        playermovement = FindObjectOfType<PlayerMovementV4>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            

            if (playermovement.airDashControLock || playermovement.zeroFriction)
            {
                playermovement.airDashControLock = false;
                playermovement.zeroFriction = false;
            }

            if (playermovement.isBouncy)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceHigh, ForceMode2D.Impulse);
            }
            else
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            }
            

        }
    }
    

}
