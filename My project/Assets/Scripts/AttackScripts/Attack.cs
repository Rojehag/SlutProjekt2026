using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Attack", order = 1)]

public class Attack : Item
{
    //This scriptable object is responsible for storing the information of an attack, such as damage, shot delay, and crit chance, as well as the projectile prefab to be instantiated when the attack is used

    //Projectile information, such as velocity, shot delay, shot spread angle, range and the projectile prefab to be instantiated when the attack is used
    [Header("Projectile information")]
    public float velocity;
    public float shotDelay;
    public int shotSpreadAngle;
    public float range;
    public GameObject projectilePrefab;

    //Damage information, such as damage, crit chance and crit bonus
    [Header("Damage information")]
    public int damage;
    public int critChance;
    public float critBonus;

   



}
