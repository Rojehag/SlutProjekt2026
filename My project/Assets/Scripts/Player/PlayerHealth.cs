using UnityEngine;

public class PlayerHealth : ChangeHealth
{
    int armorAmount;

    // Update is called once per frame
    void Update()
    {
        
    }

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
                }
            }
            else
            {
                health += amount;
            }
        }
    }

    public override void Death()
    {
        //Load death scene
        print("Player Dead");
    }
}
