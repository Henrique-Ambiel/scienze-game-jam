using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Animator animator;
    private static PlayerController instance;

    private Vector2 movement;
    public Vector2 aimDirection = Vector2.right;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        float moveX = (Input.GetKey(KeyCode.D) ? 1 : 0) +
              (Input.GetKey(KeyCode.A) ? -1 : 0);

        float moveY = (Input.GetKey(KeyCode.W) ? 1 : 0) +
                      (Input.GetKey(KeyCode.S) ? -1 : 0);

        movement = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            aimDirection = Vector2.up;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            aimDirection = Vector2.down;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            aimDirection = Vector2.left;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            aimDirection = Vector2.right;

        bool isWalking = movement != Vector2.zero;
        animator.SetBool("IsWalk", isWalking);
    }

    void FixedUpdate()
    {
        // Move o personagem aplicando velocidade física
        rb.velocity = movement * moveSpeed;
    }
}
