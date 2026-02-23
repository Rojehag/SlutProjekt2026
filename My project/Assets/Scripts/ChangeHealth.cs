using UnityEngine;

public class ChangeHealth : MonoBehaviour
{
    int health;
    int maxHealth;

    int armorAmount;

    private void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        if(health <= 0)
        {
            //Player is dead
        }
    }

    public void ChangeHealthAmount(int amount)
    {
        if (amount < 0)
        {
            if (armorAmount > 0)
            {
                armorAmount += amount;
                if (armorAmount < 0)
                {
                    health += armorAmount;
                    armorAmount = 0;
                }
            }
            else
            {
                health += amount;
            }
        }
        else
        {
            health += amount;
        }
    }
    public virtual void Death()
    {
        //Character death
    }
}
