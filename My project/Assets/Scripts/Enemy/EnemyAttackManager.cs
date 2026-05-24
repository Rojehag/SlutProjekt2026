using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    [SerializeField] Attack attack;
    [SerializeField] GameObject firePoint;

    GameObject fireTarget;

    bool attackPlayer;

    //Float to keep track of the time between projectiles, to check if the player can shoot again
    float timeBetweenProjectiles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireTarget = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Increase the time between projectiles by the time that has passed since the last frame
        timeBetweenProjectiles += Time.deltaTime;

        if (gameObject.transform.position.x - fireTarget.transform.position.x < 25 && gameObject.transform.position.x - fireTarget.transform.position.x > -25)
        {
            attackPlayer = true;
        }
        else
        {
            attackPlayer = false;
        }

        if (attackPlayer)
        {
            //Check if the left mouse button is pressed and if the time between projectiles is greater than the shot delay, if it is, call the UseAttack function
            if (timeBetweenProjectiles > attack.shotDelay)
            {
                UseAttack();
            }
        }
    }

    //Function to use the attack, which instantiates the projectile prefab at the fire point's position and resets the time between projectiles
    void UseAttack()
    {
        //Instantiate the projectile prefab at the fire point's position with no rotation
        Instantiate(attack.projectilePrefab, firePoint.transform.position, Quaternion.Euler(0, 0, 0));

        timeBetweenProjectiles = 0;
    }

    //Function to calculate the damage of the attack, which checks if a random number between 0 and 100 is less than the crit chance, if it is, it returns the damage multiplied by the crit bonus, otherwise it returns the normal damage
    public float damageAmount()
    {

        //Generate a random number between 0 and 100, if it is less than the crit chance, return the damage multiplied by the crit bonus, otherwise return the normal damage
        if (Random.Range(0, 100) < attack.critChance)
        {
            Debug.Log("Critical Hit!");
            return attack.damage * attack.critBonus;
        }
        else
        {
            return attack.damage;
        }
    }
}
