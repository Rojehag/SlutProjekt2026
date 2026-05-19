using UnityEngine;

public class RangedWepon : Wepons
{
    float range;
    int attackVelocity;

    public RangedWepon(string name, int damage, string description, float timeBetweenAttacks, float criticalChance, float range, int spriteID, int attackVelocity) : base(name, damage, description, timeBetweenAttacks, criticalChance, spriteID)
    {
        this.range = range;
        this.attackVelocity = attackVelocity;
    }

    public float GetRange()
    {
        return range;
    }
    public int GetAttackVelocity()
    {
        return attackVelocity;
    }
}
