using UnityEngine;

public class ChangeHealth : MonoBehaviour
{
    protected int health;
    int maxHealth;

    

    private void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        if(health <= 0)
        {
            Death();
        }
    }

    public virtual void ChangeHealthAmount(int amount)
    {
        
        
        health += amount;
        
    }
    public virtual void Death()
    {
        //Character death
    }
}
