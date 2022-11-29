using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RonanTestMovement : MonoBehaviour
{
    public float speed = 3f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calculateMovement();
    }

    void calculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        

        Vector3 direction = new Vector2(horizontalInput, 0f);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}


