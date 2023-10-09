using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gm;

    private Rigidbody2D playerRB;
    public float movementSpeed;
    public float jumpForce;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        gm = gameManager.AddComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {

        jump();
    }

    void horizontalMovement()
    {

    }

    void jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

        }
    }
}
