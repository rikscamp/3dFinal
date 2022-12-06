using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    PlayerMovementV4 player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovementV4>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            player.isSwimming = true;
            
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.isSwimming = false;
    }



}
