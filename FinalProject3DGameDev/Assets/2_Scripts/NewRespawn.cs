using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRespawn : MonoBehaviour
{
    public CheckpointScript checkpointScript;
    public GameObject PlayerOBJ;
    //public Rigidbody PlayerRB;
    [SerializeField] Vector3 RespawnPoint;
    [SerializeField] private float respawnSubtract = 20;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerRB = PlayerOBJ.GetComponent<Rigidbody>();
        //RespawnPoint = PlayerOBJ.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerOBJ.transform.position.y <= RespawnPoint.y - respawnSubtract)
        {
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint") && RespawnPoint != other.transform.position)
        {
            respawnSubtract = other.GetComponent<CheckpointScript>().respawnPoint;
            RespawnPoint = other.transform.position;

            Debug.Log("TRIGGERED");
        }

        //if (other.gameObject.CompareTag("Respawn"))
        //{
            //PlayerOBJ.transform.position = RespawnPoint;

            //Debug.Log("RESPAWNED");
        //}
    }

    void Respawn()
    {
        Debug.Log("Woah!");
        PlayerOBJ.transform.position = RespawnPoint;
        Debug.Log("RESPAWNED");
    }
}
