using UnityEngine;

public class PisadeiraDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;

    void Start()
    {
        // Garante que o painel começa escondido
        dialoguePanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrou no Trigger: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("É o Player!");
            dialoguePanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false);
        }
    }
}
