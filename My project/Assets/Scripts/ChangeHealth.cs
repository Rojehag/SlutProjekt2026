using UnityEngine;
using UnityEngine.UI;

public class ChangeHealth : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] float maxHealth;
    Slider healthbarSlider;

    private void Start()
    {
        healthbarSlider = gameObject.GetComponentInChildren<Slider>();
        health = maxHealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ChangeHealthAmount(-1);
        }

        if (health <= 0)
        {
            Death();
        }
    }

    protected void UpdateHealthbar()
    {
        healthbarSlider.value = health/maxHealth;
    }

    public virtual void ChangeHealthAmount(int amount)
    {
        
        
        health += amount;


        UpdateHealthbar();
    }
    public virtual void Death()
    {
        //Character death
    }

}
