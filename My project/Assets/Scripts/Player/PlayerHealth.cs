using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : ChangeHealth
{
    int armorAmount;
 

    public override void ChangeHealthAmount(int amount)
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
                    UpdateHealthbar();
                }
            }
            else
            {
                health += amount;
                UpdateHealthbar();
            }
        }
    }

    public override void Death()
    {
        SceneManager.LoadScene(0);
    }
}
