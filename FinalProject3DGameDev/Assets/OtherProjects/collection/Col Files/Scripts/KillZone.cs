using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public GameObject respawnPoint, player;
    

    void OnCollisionEnter ()
    { 
        if (col.transform.CompareTag("Player")) 
        {
            StartCoroutine(Respawn());
            //Debug.Log("RE");
        }
    }

    IEnumerator Respawn()
    {
        //Debug.Log("SPAWN");
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector2(respawnPoint.transform.position.x, respawnPoint.transform.position.y);


    }
 
}
