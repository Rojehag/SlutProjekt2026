using UnityEngine;

public class MeleeScript : Wepons
{
    float weaponHitBoxSize;

    public MeleeScript(string name, int damage, string description, float timeBetweenAttacks, float criticalChance, float weaponHitBoxSize) : base(name, damage, description, timeBetweenAttacks, criticalChance)
    {
        this.weaponHitBoxSize = weaponHitBoxSize;
    }

    public float GetWeaponHitBoxSize()
    {
        return weaponHitBoxSize;
    }
}
