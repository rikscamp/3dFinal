using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject debug;
    public GameObject enemy;
    private Transform tf;
    private int timerStart = 3;
    private float timer = 3;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        debug.SetActive(true);
        Quaternion spawnRot = Quaternion.Euler(0, 0, 0);
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            Instantiate(enemy, new Vector3(tf.position.x, tf.position.y, tf.position.z), spawnRot);
            timer = timerStart;
        }
        //Debug.Log(timer);

    }
}
