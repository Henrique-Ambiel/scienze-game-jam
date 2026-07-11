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

    public GameObject breathPrefab;
    public Transform breathSpawn;

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
        if (inventory.CanTransform() && Input.GetKeyDown(KeyCode.Space))
        {
            birdForm = !birdForm;
            UpdateForm();
        }

        if (birdForm &&
            inventory.hasShuttlecock &&
            Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
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

    void Shoot()
    {
        GameObject breath = Instantiate(
            breathPrefab,
            breathSpawn.position,
            Quaternion.identity
        );

        BreathProjectile projectile = breath.GetComponent<BreathProjectile>();

        PlayerController controller = GetComponent<PlayerController>();

        projectile.SetDirection(controller.aimDirection);

        breathSpawn.localPosition = controller.aimDirection * 0.5f;
    }
}