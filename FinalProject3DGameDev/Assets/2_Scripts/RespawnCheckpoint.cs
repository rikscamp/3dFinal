using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCheckpoint : MonoBehaviour
{
    public GameObject RespawnPoint;
    public GameObject Checkpoint;
    public GameObject Player;

    public Transform CheckpointTransform;
    public Transform PlayerTransform;
    public Transform RespawnTransform;

    public float LevelBottom;

    Vector3 PlayerStart;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStart = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Player.transform.position.y < LevelBottom)
        {
            Player.transform.position = PlayerStart;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint") && PlayerStart != other.transform.position)
        {
            PlayerStart = other.transform.position;

            Debug.Log("TRIGGERED");
        }
    }
}
