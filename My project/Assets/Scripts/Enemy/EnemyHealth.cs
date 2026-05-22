using UnityEngine;

public class EnemyHealth: ChangeHealth
{
    private void Update()
    {
        
        if (health <= 0)
        {
            Death();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeHealthAmount(-10);
        }
    }

    public override void Death()
    {
        //Play death Animation
        //Enemy death
        Destroy(gameObject);
    }
}
