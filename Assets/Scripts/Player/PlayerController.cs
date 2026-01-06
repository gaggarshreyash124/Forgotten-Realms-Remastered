using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;
    public Rigidbody2D rb;
    public InputHandler inputHandler;
    public Transform GroundCheck;
    private float CayoteeTimeCounter;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<InputHandler>();
    }
    public bool isGrounded()
    {
        return Physics2D.Raycast(GroundCheck.transform.position, Vector2.down, playerData.groundCheckDistance, playerData.groundLayer);
    }
    void Update()
    {
        Move();
        
    }
    public void Move()
    {
        rb.linearVelocityX = playerData.moveSpeed * inputHandler.MovementInput.x;
    }

    public void Jump()
    {
        if (inputHandler.JumpInput)
        {
            if (isGrounded())
            {
                rb.linearVelocityY = playerData.jumpForce;
            }
            else if (!isGrounded() && inputHandler.CanCayoteeJump)
            {
                if (CayoteeTimeCounter > 0)
                {
                    rb.linearVelocityY = playerData.jumpForce;
                    CayoteeTimeCounter = 0;
                }
            }
            
        }
    }
}
