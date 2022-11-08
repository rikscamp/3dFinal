using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] float verticalSpeed;
    [SerializeField] float inaccuracy;
    [SerializeField] int maxFlyTime;
    Rigidbody rb;
    int timeAlive;

    // Start is called before the first frame update
    void Start()
    {
        timeAlive = 0;

        //transform.Rotate(new Vector3(Random.Range(-inaccuracy, inaccuracy), Random.Range(-inaccuracy, inaccuracy), Random.Range(-inaccuracy, inaccuracy)));

        Vector3 edit = new Vector3(Random.Range(-inaccuracy, inaccuracy), Random.Range(-inaccuracy, inaccuracy), Random.Range(-inaccuracy, inaccuracy));

        rb = transform.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * verticalSpeed, ForceMode.Impulse);
        rb.AddForce(transform.forward * horizontalSpeed + edit, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeAlive >= maxFlyTime)
        {
            Destroy(gameObject);
        } else {
            timeAlive += 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 7)
        {
            Destroy(gameObject);
        }
    }
}
