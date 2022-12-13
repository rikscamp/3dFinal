using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private float speed = 4.0f;
    private Rigidbody rb;
    private GameObject player;
    private GameObject someGameObject;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        someGameObject = GameObject.Find ("Debug2");
    }

    // Update is called once per frame
    void Update()
    {
        someGameObject.SetActive(false);
        //rb.AddForce(((player.transform.position - transform.position) * speed));
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NinjaStar"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
