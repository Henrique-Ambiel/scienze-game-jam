using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }

    void FixedUpdate()
    {
        // Move o personagem aplicando velocidade física
        rb.velocity = movement * moveSpeed;
    }
}
