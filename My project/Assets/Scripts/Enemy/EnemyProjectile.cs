using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Attack attack;

    GameObject player;

    Vector2 projectileStartPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        projectileStartPosition = transform.position;
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = (player.transform.position - transform.position) * attack.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the projectile goes out of bounds by checking if the projectile's x position is greater than the starting position's x position plus 20, if it is, destroy the projectile
        if (transform.position.x > projectileStartPosition.x + 20)
        {
            Destroy(gameObject);
        }
    }

    //Function to check if the projectile collides with an enemy, if it does, it calls the ChangeHealth function of the enemy's ChangeHealth script to change the enemy's health by the damage amount of the attack, and then destroys the projectile
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check if the projectile collides with an enemy by checking if the collided object has the tag "Enemy", if it does, call the ChangeHealth function of the enemy's ChangeHealth script to change the enemy's health by the damage amount of the attack, and then destroy the projectile
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ChangeHealth>().ChangeHealthAmount(-attack.damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
