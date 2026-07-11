using UnityEngine;

public class PlayerForm : MonoBehaviour
{
    public bool birdForm;

    private PlayerController controller;
    private PlayerVision vision;
    private Animator animator;
    private PlayerInventory inventory;

    [Header("Velocidades")]
    public float oldWomanSpeed = 2f;
    public float birdSpeed = 5f;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        vision = GetComponent<PlayerVision>();
        animator = GetComponent<Animator>();
        inventory = GetComponent<PlayerInventory>();

        UpdateForm();
    }

    void Update()
    {
        // Apenas para teste
        if (inventory.CanTransform() && Input.GetKeyDown(KeyCode.Space))
        {
            birdForm = !birdForm;
            UpdateForm();
        }
    }

    void UpdateForm()
    {
        controller.moveSpeed = birdForm ?
            birdSpeed :
            oldWomanSpeed;

        vision.SetBirdForm(birdForm);

        animator.SetBool("BirdForm", birdForm);
    }
}