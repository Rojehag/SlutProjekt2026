using UnityEngine;

public class Projectile : MonoBehaviour
{
    //This script is responsible for the projectile's movement and damage, as well as destroying the projectile when it collides with an enemy or goes out of bounds

    //Attack scriptable object to store the attack's information, such as damage and velocity
    [SerializeField] Attack attack;

    //Rigidbody2D component of the projectile to apply velocity to it
    Rigidbody2D rigidbody;

    //GameObject of the player to check the direction of the player for the projectile's movement
    GameObject player;

    //Vector3 to store the projectile's starting position to check if it goes out of bounds
    Vector3 projectileStartPosition;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get the Rigidbody2D component of the projectile to apply velocity to it
        rigidbody = GetComponent<Rigidbody2D>();

        //Find the player GameObject to check the direction of the player for the projectile's movement
        player = GameObject.FindGameObjectWithTag("Player");
        

        //Store the projectile's starting position to check if it goes out of bounds
        projectileStartPosition = transform.position;


        //Check the direction of the player for the projectile's movement
        if (player.GetComponent<PlayerMovment>().directionOfPlayer == true)
        {
            rigidbody.linearVelocity = new Vector2(1, 0) * attack.velocity;
        }
        else if (player.GetComponent<PlayerMovment>().directionOfPlayer == false)
        {
            rigidbody.linearVelocity = new Vector2(-1, 0) * attack.velocity;
        }

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
        if (collision.gameObject.CompareTag("Enemy"))
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
