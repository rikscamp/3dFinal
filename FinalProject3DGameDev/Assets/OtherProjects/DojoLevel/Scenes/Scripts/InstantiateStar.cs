using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateStar : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject NinjaStar;
    private GameObject player;
    private PlayerMovement playerMovement;
    private Transform playerTransform;
    Quaternion playerRot;
    Vector3 playerPos;
    bool clicking;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); // Calls the player movement scripts so we can look at the rotation of the head
        // I would put star instantiation in the player movement script itself but that's cluttered enough as it is
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Head");
        playerTransform = player.GetComponent<Transform>();
        clicking = Input.GetKeyDown(KeyCode.Mouse0);
        playerRot = Quaternion.Euler(0, playerMovement.rot.y + 90, 0); // converts the player's look rotation (vector3) into a quaternion because unity hates type conversions

        if (clicking)
        {
            InstantiateNewStar();
        }

    }


    private void InstantiateNewStar()
    {
        Object.Instantiate(NinjaStar, player.gameObject.transform.position, playerRot);
    }
}
