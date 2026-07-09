using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private static PlayerController instance;

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

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        // Captura o input do teclado (detecta tanto WASD quanto as Setas)
        // "Horizontal" = A/D ou Seta Esquerda/Direita
        // "Vertical" = W/S ou Seta Cima/Baixo
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Normaliza o vetor para evitar que o personagem ande mais rápido na diagonal
        movement = new Vector2(moveX, moveY).normalized;

        bool isWalking = movement != Vector2.zero;
        animator.SetBool("IsWalk", isWalking);
    }

    void FixedUpdate()
    {
        // Move o personagem aplicando velocidade física
        rb.velocity = movement * moveSpeed;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SpawnPoint spawn = FindFirstObjectByType<SpawnPoint>();

        if (spawn != null)
        {
            transform.position = spawn.transform.position;
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
