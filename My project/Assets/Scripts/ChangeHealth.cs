using UnityEngine;
using UnityEngine.UI;

public class ChangeHealth : MonoBehaviour
{
    //This script is responsible for changing the health of the player and enemies, as well as updating the healthbar

    //Health and max health of the character
    [SerializeField] protected float health;
    [SerializeField] float maxHealth;

    //Slider for the healthbar
    Slider healthbarSlider;

    private void Start()
    {
        healthbarSlider = gameObject.GetComponentInChildren<Slider>();

        //Set the health to the max health at the start of the game
        health = maxHealth;
    }
    private void Update()
    {

        //Check if the health is less than or equal to 0, if it is, call the Death function
        if (health <= 0)
        {
            Death();
        }
    }

    //Update the healthbar slider value to the current health divided by the max health
    protected void UpdateHealthbar()
    {
        healthbarSlider.value = health/maxHealth;
    }

    //Change the health of the character by the amount passed in the parameter, and then update the healthbar
    public virtual void ChangeHealthAmount(int amount)
    {
        
        
        health += amount;


        UpdateHealthbar();
    }

    //Function to be called when the character dies, can be overridden by the player and enemies to do different things on death
    public virtual void Death()
    {
        //Character death
    }

}
