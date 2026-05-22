using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "New Attack", menuName = "Attack")]

public class Attack : ScriptableObject
{
    [Header("Projectile information")]
    public float velocity;
    public float shotDelay;
    public int shotSpreadAngle;
    public float range;
    public GameObject projectilePrefab;


    [Header("Damage information")]
    public int damage;
    public int critChance;
    public float critBonus;

    public float damageAmount()
    {
        if (Random.Range(0, 100) < critChance)
        {
            Debug.Log("Critical Hit!");
            return damage * critBonus;
        }
        else
        {
            return damage;
        }
    }


}
