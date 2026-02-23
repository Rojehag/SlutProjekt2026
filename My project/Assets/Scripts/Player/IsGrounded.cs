using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    //Bool to check if the player is on the ground or not
    public bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //Checks if the player is on the ground or not by checking if the player is colliding with the ground
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    //Checks if the player is not on the ground by checking if the player is not colliding with the ground
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
