using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{

    public float movementSpeed;
    public float leftOffset;
    public float rightOffset;
    private bool moveRight;
    private float startPositionX;
    private float inputHorizontal;
    private Rigidbody2D enemyRB;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        moveRight = false;
        startPositionX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
    }

    private void moveEnemy()
    {
        if (moveRight)
        {
            //move the enemy right
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        else
        {
            //move the enemy left
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }

        if (transform.position.x <= startPositionX - leftOffset)
        {
            moveRight = true;
        }
        else if (transform.position.x >= startPositionX+rightOffset)
        {
            moveRight = false;
        }

        //horizontalMovement();
    }

    private void horizontalMovement()
    {
        //"Horizontal" is defined in the input section of project settings
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        enemyRB.velocity = new Vector2(inputHorizontal * movementSpeed, enemyRB.velocity.y);
        flipEnemy();
    }

    private void flipEnemy()
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

    

}
