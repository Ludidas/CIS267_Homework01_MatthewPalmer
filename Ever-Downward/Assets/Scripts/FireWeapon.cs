using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject projectile;
    public PowerUp powerUp;
    public Transform muzzle;

    public float firingRate;
    private float timeBetweenShots;
    private bool canFire = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Only works if the wizard power up is active
        //If the timeBetweenShots is less than or equal to zero I can shoot my weapon
        if (timeBetweenShots <= 0)
        {
            //Reset timeBetweenShots to the specified firingRate
            timeBetweenShots = firingRate;
            //allow the player to fire their gun
            canFire = true;
        }
        else
        {
            //If the timeBetweenShots is not less than or equal to zero you cannot fire yet
            //i will deduct time from timeBetweenShots until it is 0 allowing the player
            //to shoot their weapon again.
            timeBetweenShots -= Time.deltaTime;
        }

        //If left mouse button is clicked
        if (Input.GetButtonDown("Fire1"))
        {
            if (canFire)
            {
                //After you fire you have to wait a specified amount of time 
                //to fire again so set the boolean to false.
                canFire = false;
                shootGun();
            }
        }

    }

    void shootGun()
    {
        Instantiate(projectile, muzzle.position, transform.rotation);
    }
}
