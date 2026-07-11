using UnityEngine;

public class BreathProjectile : MonoBehaviour
{
    public float speed = 8f;
    public float lifeTime = 3f;

    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Breakable"))
        {
            BreakableObject breakable = other.GetComponent<BreakableObject>();

            if (breakable != null)
            {
                breakable.Break();
            }

            Destroy(gameObject);
        }
    }
}
