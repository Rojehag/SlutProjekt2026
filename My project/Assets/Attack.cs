using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "New Attack", menuName = "Attack")]

public class Attack : ScriptableObject
{
    [Header("Projectile information")]
    [SerializeField] float velocity;
    [SerializeField] float shotDelay;
    [SerializeField] int shotSpreadAngle;
    [SerializeField] float range;
    [SerializeField] GameObject firePoint;
    [SerializeField] GameObject fireObject;

    [Header("Damage information")]
    [SerializeField] int damage;
    [SerializeField] int critChance;
    [SerializeField] float critBonus;

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

    public void ShootWepon()
    {
        Instantiate(fireObject, new Vector2(firePoint.transform.position.x, firePoint.transform.position.y), Quaternion.EulerRotation(0,90 + Random.RandomRange(0,shotSpreadAngle),0 ));

    }
}
