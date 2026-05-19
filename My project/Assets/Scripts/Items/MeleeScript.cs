using UnityEngine;

public class MeleeScript : Wepons
{
    float weaponHitBoxSize;

    public MeleeScript(string name, int damage, string description, float timeBetweenAttacks, float criticalChance, float weaponHitBoxSize, int spriteID) : base(name, damage, description, timeBetweenAttacks, criticalChance, spriteID)
    {
        this.weaponHitBoxSize = weaponHitBoxSize;
    }

    public float GetWeaponHitBoxSize()
    {
        return weaponHitBoxSize;
    }
}
