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
    public float jumpBufferLength;

    //Private variables
    private Rigidbody2D playerRB;
    private float inputHorizontal;
    private bool isGrounded;
    private float hangCounter;
    private float jumpBufferCount;

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
        jumpBuffer();

        if (jumpBufferCount>0 && hangCounter > 0)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);

            isGrounded = false;
            jumpBufferCount = 0;
        }

        //Allows for shorthopping if space bar is released
        if(Input.GetKeyUp(KeyCode.Space) && playerRB.velocity.y > 0)
        {
            playerRB.velocity=new Vector2(playerRB.velocity.x, playerRB.velocity.y * 0.5f);
        }


    }

    //Adds hang-timer, which allows for jumping even momentarily after a player falls off of a platform
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

    //Allows for jump input slightly before landing
    private void jumpBuffer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCount = jumpBufferLength;
        }
        else 
        { 
            jumpBufferCount -= Time.deltaTime; 
        }
    }
    //When a platform is being stood on, sets grounded boolean to true
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
    //When a platform is no longer being stood on, sets grounded boolean to false
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded=false;
    }

    //For collectables
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Scroll") || collision.gameObject.CompareTag("Ring") || collision.gameObject.CompareTag("Diamond"))
        {
            //get value of collectable
            int collectableValue = collision.GetComponent<Collectables>().getCollectableValue();
            //destroy the collectable
            collision.GetComponent<Collectables>().destroyCollectable();
            //add to player score
            GetComponent<PlayerScore>().setGold(collectableValue);
        }

        
    }
}
