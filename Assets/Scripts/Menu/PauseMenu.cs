using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused = false;

    public PlayerInventory inventory;

    public TMPro.TextMeshProUGUI objectivesText;

    void Start()
    {
        pausePanel.SetActive(false);

        if (inventory == null)
        {
            inventory = FindFirstObjectByType<PlayerInventory>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (isPaused)
        {
            UpdateObjectives();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        pausePanel.SetActive(isPaused);

        Time.timeScale = isPaused ? 0 : 1;

        if (isPaused)
            UpdateObjectives();
    }

    void UpdateObjectives()
    {
        Debug.Log("Inventory: " + inventory);

        Debug.Log("Tamanco: " + inventory.hasShoe);
        Debug.Log("Flor: " + inventory.hasFlower);
        Debug.Log("Flauta: " + inventory.hasFlute);
        Debug.Log("Peteca: " + inventory.hasShuttlecock);

        objectivesText.text = "";

        objectivesText.text += inventory.hasShoe ?
            "[X] Tamanco\n" :
            "[ ] Tamanco\n";

        objectivesText.text += inventory.hasFlower ?
            "[X] Flor\n" :
            "[ ] Flor\n";

        objectivesText.text += inventory.hasFlute ?
            "[X] Flauta (Transformação)\n" :
            "[ ] Flauta (Transformação)\n";

        objectivesText.text += inventory.hasShuttlecock ?
            "[X] Peteca (Super Sopro)\n" :
            "[ ] Peteca (Super Sopro)\n";

        objectivesText.text += GoatHealth.goatDefeated ?
            "[X] Derrotar Cabra Cabriola" :
            "[ ] Derrotar Cabra Cabriola";
    }
}
