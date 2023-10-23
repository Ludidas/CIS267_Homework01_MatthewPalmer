using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform muzzle;

    public float firingRate;
    private float timeBetweenShots;
    private bool canFire = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void shootGun()
    {
        Instantiate(projectile, muzzle.position, transform.rotation);
    }
}
