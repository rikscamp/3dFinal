using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnDelay;
    [SerializeField] float spawnRadius;
    [SerializeField] int maxSpawns;
    [SerializeField] GameObject thing;

    List<Transform> objects;
    Vector3 spawnLoc;
    bool spawning;
    int currentAgents;

    // Start is called before the first frame update
    void Start()
    {
        objects = new List<Transform>();
        spawning = false;
        currentAgents = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAgents < maxSpawns  && !spawning)
        {
            Debug.Log("Spawn queued");

            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        spawning = true;

        yield return new WaitForSeconds(spawnDelay);

        spawnLoc = new Vector3(Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius)) + transform.position;

        GameObject newObject = Instantiate(thing, spawnLoc, Quaternion.identity).gameObject;

        newObject.transform.parent = transform;

        currentAgents += 1;

        spawning = false;

        Debug.Log("Spawn complete");
    }

    public void Notify()
    {
        currentAgents -= 1;
    }
}
