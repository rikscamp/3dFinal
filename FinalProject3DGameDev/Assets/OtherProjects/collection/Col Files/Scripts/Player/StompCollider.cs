using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompCollider : MonoBehaviour
{
    PlayerMovementV4 playermovement;


    [SerializeField] private float bounce;
    [SerializeField] private float bounceHigh;
    public Rigidbody2D rb2D;


    private void Awake()
    {
        playermovement = FindObjectOfType<PlayerMovementV4>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (playermovement.isBouncy)
            {
                Destroy(other.gameObject);
                rb2D.velocity = new Vector2(rb2D.velocity.x, bounceHigh);
                Debug.Log("BounceHigher");
            }
            else
            {
                Destroy(other.gameObject);
                rb2D.velocity = new Vector2(rb2D.velocity.x, bounce);
                Debug.Log("smallBounce");
            }
            
        }

        if (playermovement.airDashControLock)
        {
            playermovement.airDashControLock = false;
            playermovement.zeroFriction = false;
        }
    }
}
