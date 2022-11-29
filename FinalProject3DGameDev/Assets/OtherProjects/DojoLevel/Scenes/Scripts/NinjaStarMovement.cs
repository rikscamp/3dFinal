using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarMovement : MonoBehaviour
{
    private Rigidbody rb;
    private CapsuleCollider playerColl;
    private BoxCollider ninjaStarColl;
    private float timer = 3;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
        rb.AddForce(-transform.right * 30, ForceMode.Impulse); // star go pew pew
    }

    // Update is called once per frame
    void Update()
    {
        IgnorePlayerColl();
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }

    void IgnorePlayerColl()
    {
        ninjaStarColl = GetComponent<BoxCollider>();
        playerColl = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider>();
        Physics.IgnoreCollision(playerColl, ninjaStarColl);
    }
}
