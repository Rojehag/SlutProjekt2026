using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : ChangeHealth
{
    //This script is responsible for changing the health of the player, as well as updating the healthbar and handling the player's death

    //Amount of armor the player has, which will be used to reduce the damage taken by the player
    int armorAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void ChangeHealthAmount(int amount)
    {
        print("Taking damage: " + amount);
        //If the amount is less than 0, it means the player is taking damage, so we need to check if the player has any armor to reduce the damage taken
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
        else
        {

            health += amount;
            UpdateHealthbar();
        }
    }

    //Function to be called when the player dies, which will load the first scene (the main menu)
    public override void Death()
    {
        SceneManager.LoadScene(0);
    }
}
