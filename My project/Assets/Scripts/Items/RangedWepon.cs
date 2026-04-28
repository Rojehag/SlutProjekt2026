using UnityEngine;

public class RangedWepon : Wepons
{
    float range;

    public RangedWepon(string name, int damage, string description, float timeBetweenAttacks, float criticalChance, float range) : base(name, damage, description, timeBetweenAttacks, criticalChance)
    {
        this.range = range;
    }

    public float GetRange()
    {
        return range;
    }
}
