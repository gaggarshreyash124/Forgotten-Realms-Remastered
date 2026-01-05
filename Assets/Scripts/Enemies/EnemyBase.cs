using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public EnemyData enemydata{get; private set;}
    public Animator anim{get; private set;}
    public Rigidbody2D rb{get; private set;}
    public int facingdirection = 1;
    public GameObject Enemy;
    private Vector2 velocityWorkspace;

    public float cooldown = 4f;


    public void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }

    public void Update()
    {
        
    }
    public void flip()
    {
        facingdirection *= -1;
        enemydata.patrolSpeed *= -1;
        transform.Rotate(0f, 180f, 0f);
    }

#region move
    public void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(facingdirection * velocity, rb.linearVelocity.y);
        rb.linearVelocity = velocityWorkspace;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PatrolPoint"))
        {
            flip();
        }
    }
#endregion

    public void PLayerFollow()
    {
        float t = Time.time;
        if(Time.time-t>=cooldown)
        {
            cooldown+=4f;
        }
    }
}