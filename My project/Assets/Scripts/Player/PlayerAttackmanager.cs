using UnityEngine;

public class PlayerAttackmanager : MonoBehaviour
{
    [SerializeField] Attack attack;
    [SerializeField] GameObject firePoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Attack");
        }
    }

    void UseAttack()
    {
        Quaternion rotation = Quaternion.Euler(0, 90-(attack.shotSpreadAngle/2) + Random.Range(0, attack.shotSpreadAngle), 0);
        Instantiate(attack.projectilePrefab, firePoint.transform.position, rotation);
    }
}
