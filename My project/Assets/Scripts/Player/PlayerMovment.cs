using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody2D playerRb;
    [SerializeField] GameObject groundCheck;

    [SerializeField] int playerjumpPower;
    [SerializeField] int playerSpeed = 5;

    float gravity = 9.82f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            Movment(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Movment(Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.GetComponent<IsGrounded>().isGrounded)
        {
            MovmentUp();
        }

    }

    void Movment(Vector2 direction)
    {
        playerRb.linearVelocity = direction * playerSpeed;
    }
    
    void MovmentUp()
    {
        playerRb.AddForce(Vector2.up * playerjumpPower, ForceMode2D.Impulse);
    }

  

    private void FixedUpdate()
    {
        if (!groundCheck.GetComponent<IsGrounded>().isGrounded)
        {
            playerRb.AddForce(Vector2.down * gravity);
        }
        else
        {
            playerRb.linearVelocity = Vector2.down * 0;
        }
    }
}
