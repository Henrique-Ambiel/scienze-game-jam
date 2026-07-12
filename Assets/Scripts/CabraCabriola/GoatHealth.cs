using UnityEngine;

public class GoatHealth : MonoBehaviour
{
    public int maxHealth = 3;

    public static bool goatDefeated = false;

    private int currentHealth;
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Vida da Cabra: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Cabra derrotada!");

        goatDefeated = true;

        Destroy(gameObject);
    }
}