using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;
    public Rigidbody2D rb;
    public InputHandler inputHandler;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<InputHandler>();

    }
    void Update()
    {
        Move();
        if (inputHandler.JumpInput)
        {
            Jump();
        }
    }
    public void Move()
    {
        rb.linearVelocityX = playerData.moveSpeed * inputHandler.MovementInput.x;
    }
    public void Jump()
    {
        rb.linearVelocityY = playerData.jumpForce;
    }
}
