using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MeleeWeapon", order = 3)]
public class MeleeScript : Item
{
    //This is the class for all melee wepons it contains the basic stats that all melee wepons have and then the sword and axe classes will inherit from this and add their own stats
    public float weaponHitBoxSize;
    //Stats
    public int damage;
    public float timeBetweenAttacks;
    public float criticalChance;


}
