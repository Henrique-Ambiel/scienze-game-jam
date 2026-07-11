using UnityEngine;

public class River : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerForm form = other.GetComponent<PlayerForm>();

        if (!form.birdForm)
        {
            other.GetComponent<PlayerHealth>().TakeDamage(999);
        }
    }
}
