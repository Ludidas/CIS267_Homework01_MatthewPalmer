using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gm;

    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    public float jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        gm = gameManager.AddComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
