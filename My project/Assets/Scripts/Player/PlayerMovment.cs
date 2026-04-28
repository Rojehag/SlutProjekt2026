using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]LayerMask groundLayer;

    //This script is responsible for the player's movement and jump
    Rigidbody2D playerRb;
    //Ground check to check if the player is on the ground or not
    [SerializeField] GameObject groundCheck;

    [Header("Player Locomotion")]
    [SerializeField] int playerjumpPower;
    [SerializeField] int playerSpeed = 5;
    [SerializeField] float acceleration;

    [Header("Particle System")]
    [SerializeField]ParticleSystem particleSystem;


    //Player direction to check the direction of the player
    Vector2 playerDirection;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement and jump
        if (Input.GetKey(KeyCode.A))
        {
            Movment(new Vector2(-playerSpeed, playerRb.linearVelocity.y),0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Movment(new Vector2(playerSpeed, playerRb.linearVelocity.y), -172);
        }
        else
        {
            particleSystem.Stop();
            Movment(new Vector2(0, playerRb.linearVelocityY),0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && CheckIfGrounded())
        {
            MovmentUp();
        }

       
    }

    //Function to move the player in the direction of the input and speed
    void Movment(Vector2 direction, int rotation)
    {
        if (CheckIfGrounded() && particleSystem.isStopped) 
        {
            particleSystem.Play();
        }
        StartCoroutine(WaitForParticleSystem(rotation));
        playerRb.linearVelocity = new(Mathf.Lerp(playerRb.linearVelocityX, direction.x, Time.deltaTime * acceleration), direction.y);
    }

    //Function to move the player up in the direction of the input and jump power
    void MovmentUp()
    {
        playerRb.AddForce(Vector2.up * playerjumpPower, ForceMode2D.Impulse);
    }

    public bool CheckIfGrounded()
    {
       RaycastHit2D[] colliders = Physics2D.BoxCastAll(groundCheck.transform.position, new Vector2(0.95f, 0.2f),0, Vector2.down, 0.5f, groundLayer);
        return colliders.Length > 0;

    }
    IEnumerator WaitForParticleSystem(int rotation)
    {
        yield return new WaitForSeconds(1f);

        particleSystem.transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

}
