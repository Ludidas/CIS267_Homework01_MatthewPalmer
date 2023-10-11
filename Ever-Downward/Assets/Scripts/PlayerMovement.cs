using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //GameManager
    public GameObject gameManager;
    private GameManager gm;

    //Unity-interfaced Variables
    public float movementSpeed;
    public float jumpForce;
    public float hangTime;

    //Private variables
    private Rigidbody2D playerRB;
    private float inputHorizontal;
    private bool isGrounded;
    private float hangCounter;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        gm = gameManager.AddComponent<GameManager>();
        //if jumpTrigger is set to True, the player cannot jump, and vice versa
        isGrounded = false;

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement();
        jump();
    }

    private void horizontalMovement()
    {
        //"Horizontal" is defined in the input section of project settings
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        playerRB.velocity = new Vector2(inputHorizontal * movementSpeed, playerRB.velocity.y);
        flipPlayer();
    }

    private void flipPlayer()
    {
        if (inputHorizontal > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        else if (inputHorizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    //maybe change the way jumping is calculated
    private void jump()
    {
        hangTimer();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded==true)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);

            isGrounded = false;
        }

        //Allows for shorthopping if space bar is released
        if(Input.GetKeyUp(KeyCode.Space) && playerRB.velocity.y > 0)
        {
            playerRB.velocity=new Vector2(playerRB.velocity.x, playerRB.velocity.y * 0.5f);
        }


    }

    //currently doesn't work
    private void hangTimer()
    {
        if (isGrounded)
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject);

        if (collision.gameObject.CompareTag("Lava"))
        {
            //gm.setGameOver(true);

        }
        else if (collision.gameObject.CompareTag("Grounded"))
        {
            isGrounded = true;
        }


    }

    //For collectables
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
