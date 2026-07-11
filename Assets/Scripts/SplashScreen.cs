using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float splashTime = 3f;

    void Start()
    {
        Invoke(nameof(LoadMenu), splashTime);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
