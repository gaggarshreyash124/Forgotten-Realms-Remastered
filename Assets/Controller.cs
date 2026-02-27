using UnityEngine;

public class Controller : MonoBehaviour,IDamagable
{
    //Component Variables
    public PlayerInputHandler inputHandler;
    public Rigidbody2D rb;
    //Combat System
    public float MaxHealth = 100f;
    float CurrentHealth;
    public LayerMask enemyLayer;
    public float Attack;

    //Movement
    public float MoveSpeed = 5f;

    //Jump
    public float JumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public Transform WallCheck;

    //Flip
    public float facingDirection = 1f;

    //Wall Slide
    public bool isSliding;
    public float SlideSpeed = 3f;

    //Wall Jump
    public float WallJumpDirection;
    public float WalljumpCounter;
    public float WallJumpTime;
    public bool iswalljumping;
    public Vector2 Walljumpforce = new Vector2(8f,16f);


    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<PlayerInputHandler>();
    }
    void Start()
    {
        CurrentHealth = MaxHealth;
    }
    private bool isGrounded()
    {
        return Physics2D.Raycast(groundCheck.transform.position, Vector2.down, 0.1f, groundLayer);
    }
    public bool isWalled()
    {
        return Physics2D.OverlapCircle(WallCheck.position,0.1f,groundLayer);
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(1, 1), 0, Vector2.right, 0.1f, LayerMask.GetMask("Enemy"));
        
        Jump();
        Wallslide();
        WallJump();

        if (!iswalljumping)
        {
            Move();
            
        }

        if (inputHandler.moveInput.x > 0 && facingDirection == 1)
        {
            Flip();
        }
        else if (inputHandler.moveInput.x < 0 && facingDirection == -1)
        {
            Flip();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable damagable = collision.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(Attack);
        }
    }

    public void Move()
    {
        rb.linearVelocityX = MoveSpeed * inputHandler.moveInput.x;
    }
    public void Jump()
    {
        if (inputHandler.jumpInput && isGrounded())
        {
            rb.linearVelocityY = JumpForce;
        }
    }

    public void Wallslide()
    {
        if (isWalled() && !isGrounded() && inputHandler.moveInput != Vector2.zero)
        {
            isSliding = true;
            rb.linearVelocityY = Mathf.Clamp(rb.linearVelocityY, -SlideSpeed, float.MaxValue);
        }
        else
        {
            isSliding = false;
        }
    }

    public void WallJump()
    {
        if (isSliding)
        {
            iswalljumping = false;
            WalljumpCounter = WallJumpTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            WalljumpCounter -= Time.deltaTime;
        }

        if (inputHandler.jumpInput && WalljumpCounter >= 0)
        {
            iswalljumping = true;
            WallJumpDirection *= -facingDirection;
            rb.linearVelocity = new Vector2(WallJumpDirection * Walljumpforce.x,Walljumpforce.y);
            WalljumpCounter = 0;
            Invoke(nameof(StopWallJumping),.5f);
        }
    }

    public void StopWallJumping()
    {
        iswalljumping = false;
    }
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Debug.Log("Player Dead");
        }
    }

    public void Flip()
    {
        facingDirection *= -1f;
        transform.Rotate(0f, 180f, 0f);
    }
}

public interface IDamagable
{
    void TakeDamage(float damage);
    
}
