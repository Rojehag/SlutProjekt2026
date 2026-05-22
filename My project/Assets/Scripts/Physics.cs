using UnityEngine;

public class Physics : MonoBehaviour
{
    Rigidbody2D playerRb;
    [SerializeField] float gravity = 9.82f;
    public Vector2 playerDirection;

    //Ground check to check if the player is on the ground or not
    [SerializeField] GameObject groundCheck;

    [SerializeField] LayerMask groundLayer;

    float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!CheckIfGrounded())
        {
            playerDirection.y = gravity * playerRb.mass;
        }
        else
        {
            playerDirection.y = 0;
        }

        playerRb.AddForce(-playerDirection, ForceMode2D.Force);
    }
    public bool CheckIfGrounded()
    {
        RaycastHit2D[] colliders = Physics2D.BoxCastAll(groundCheck.transform.position, new Vector2(0.5f, 0.2f), 0, Vector2.down, 0.5f, groundLayer);
        return colliders.Length > 0;

    }
}
