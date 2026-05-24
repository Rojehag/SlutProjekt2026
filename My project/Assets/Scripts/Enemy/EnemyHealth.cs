using UnityEngine;

public class EnemyHealth: ChangeHealth
{
    //This script is responsible for changing the health of the enemy, as well as handling the enemy's death
    private void Update()
    {
        
        if (health <= 0)
        {
            Death();
        }

        
    }

    //Function to be called when the enemy dies, which will play the death animation and then destroy the enemy game object
    public override void Death()
    {
        //Play death Animation
        //Enemy death
        Destroy(gameObject);
    }
}
