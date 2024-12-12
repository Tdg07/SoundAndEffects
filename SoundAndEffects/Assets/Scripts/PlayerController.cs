using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 1;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround) 
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }  if (collision.gameObject.CompareTag("Obstacle")) 
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
    }
}
