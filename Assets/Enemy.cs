using UnityEngine;

public class Enemy : MonoBehaviour,IDamagable
{
    public float MaxHealth = 50f;
    public float Attack = 10f;
    float CurrentHealth;
    public LayerMask playerLayer;


    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Debug.Log("Enemy Dead");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(Attack);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
