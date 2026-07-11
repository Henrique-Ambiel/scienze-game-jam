using UnityEngine;

public class GoatAI : MonoBehaviour
{
    [Header("Referências")]
    public Transform player;

    [Header("Movimentação")]
    public float moveSpeed = 2f;
    public float chaseDistance = 5f;

    [Header("Ataque")]
    public int damage = 1;
    public float attackDistance = 0.8f;
    public float attackCooldown = 1f;

    private float nextAttackTime;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= chaseDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            rb.velocity = direction * moveSpeed;

            animator.SetBool("IsWalking", true);
        }
        else
        {
            rb.velocity = Vector2.zero;

            animator.SetBool("IsWalking", false);
        }

        if (distance <= attackDistance && Time.time >= nextAttackTime)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            nextAttackTime = Time.time + attackCooldown;
        }
    }
}
