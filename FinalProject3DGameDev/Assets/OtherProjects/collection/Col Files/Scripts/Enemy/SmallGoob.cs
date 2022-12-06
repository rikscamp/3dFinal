using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGoob : BasicEnemy
{
    public float distance;

    public bool movingLeft = true;
    public bool detectwall = false;

    public Transform groundDetection;
    public Transform wallDetection;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);


        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, LayerMask.GetMask("isGround"));

        if (groundInfo.collider == false)
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }

        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.left, .01f , LayerMask.GetMask("isGround"));

        if(wallInfo.collider == true)
        {
            if(movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingLeft = false;
            }
        else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }
         


    }
}
