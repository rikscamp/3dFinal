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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y < LevelBottom)
        {
            Player.transform.position = CheckpointTransform.position;
        }
    }
}
