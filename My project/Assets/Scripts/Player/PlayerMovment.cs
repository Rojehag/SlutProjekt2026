using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    

    //This script is responsible for the player's movement and jump
    Rigidbody2D playerRb;

    //Player speed and jump power
    [Header("Player Locomotion")]
    [SerializeField] int playerjumpPower;
    [SerializeField] int playerSpeed = 5;
    [SerializeField] float acceleration;


    //Particle system for the player's movement
    [Header("Particle System")]
    [SerializeField]ParticleSystem particleSystem;

    //Animator for the player's movement
    [Header("Animation")]
    [SerializeField] Animator playerAnim;

    //Bool to check the direction of the player for the shooting script
    public bool directionOfPlayer;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       directionOfPlayer = true;
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement, checking direction of the player and playing the particle system and animation
        if (Input.GetKey(KeyCode.A))
        {
            directionOfPlayer = false;
            print(directionOfPlayer);

            Movment(new Vector2(-playerSpeed, playerRb.linearVelocity.y),0,180, true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            directionOfPlayer = true;
            print(directionOfPlayer);

            Movment(new Vector2(playerSpeed, playerRb.linearVelocity.y), -172,0, true);
            
        }
        else
        {
            particleSystem.Stop();
            Movment(new Vector2(0, playerRb.linearVelocityY),100,100, false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<Physics>().CheckIfGrounded())
        {
            MovmentUp();
        }

       
    }

    //Function to move the player in the direction of the input and speed
    void Movment(Vector2 direction, int rotation, int rotationZ , bool animation)
    {
        //Check if the player is grounded and play the particle system and animation accordingly
        if (GetComponent<Physics>().CheckIfGrounded()&& particleSystem.isStopped) 
        {
            particleSystem.Play();
            
        }
        else if (!GetComponent<Physics>().CheckIfGrounded() && particleSystem.isPlaying)
        {
            particleSystem.Stop();
            playerAnim.SetBool("PlayerRun", false);
        }

        //Rotate the player in the direction of the input
        if (rotationZ!= 100)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, rotationZ, 0);
            particleSystem.transform.rotation = Quaternion.Euler(0, rotation, 0);
        }

        //Play the animation of the player running
        if (animation)
        {
            playerAnim.SetBool("PlayerRun", true);
        }else
        {
            playerAnim.SetBool("PlayerRun", false);
        }

        //Move the player in the direction of the input and speed
        playerRb.linearVelocity = new(Mathf.Lerp(playerRb.linearVelocityX, direction.x, Time.deltaTime * acceleration), direction.y);
    }

    //Function to move the player up in the direction of the input and jump power
    void MovmentUp()
    {
        //Move the player up in the direction of the input and jump power
        playerRb.AddForce(Vector2.up * playerjumpPower, ForceMode2D.Impulse);
        particleSystem.Stop();
    }

}
