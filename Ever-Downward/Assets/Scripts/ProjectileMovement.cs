using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float projectileDamage;
    public float projectileSpeed;
    public float projectileLife;

    // Start is called before the first frame update
    void Start()
    {
        //call the destroyBullet function after bulletLife seconds
        Invoke("destroyProjectile", projectileLife);
    }

    // Update is called once per frame
    void Update()
    {
        //You can still use tranlate to move the bullet as long as either the bullet
        //or the enemy contains a rigidbody.
        //You cannot detect collisions unless one of the game objects has a rigidbody
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    void destroyProjectile()
    {
        //Remove the projectile from the screen
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemies>().destroyEnemy();
        }
        if (collision.gameObject.CompareTag("Crow"))
        {
            collision.gameObject.GetComponent<Crow>().flipCrow();
        }

    }
}
