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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
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
        objectivesText.text = "";

        objectivesText.text += inventory.hasShoe ?
            "☑ Tamanco\n" :
            "☐ Tamanco\n";

        objectivesText.text += inventory.hasFlower ?
            "☑ Flor\n" :
            "☐ Flor\n";

        objectivesText.text += inventory.hasFlute ?
            "☑ Flauta (Transformação)\n" :
            "☐ Flauta (Transformação)\n";

        objectivesText.text += inventory.hasShuttlecock ?
            "☑ Peteca (Super Sopro)\n" :
            "☐ Peteca (Super Sopro)\n";

        objectivesText.text += GoatHealth.goatDefeated ?
            "☑ Derrotar Cabra Cabriolli" :
            "☐ Derrotar Cabra Cabriolli";
    }
}
