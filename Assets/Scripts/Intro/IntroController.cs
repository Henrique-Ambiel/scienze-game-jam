using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroController : MonoBehaviour
{
    [Header("Configurações")]
    public VideoPlayer videoPlayer;
    public string gameplaySceneName = "GameplayScene";

    [Header("Botão")]
    public GameObject skipButton;

    private bool hasFinished = false;

    private void Start()
    {
        // Garante que o botão começa escondido
        if (skipButton != null)
        {
            skipButton.SetActive(false);
        }

        // Quando o vídeo terminar chama essa função
        videoPlayer.loopPointReached += VideoFinished;

        // Começa o vídeo
        videoPlayer.Play();

        // Mostra o botão depois de alguns segundos
        Invoke(nameof(ShowSkipButton), 2f);
    }


    private void ShowSkipButton()
    {
        if (skipButton != null)
        {
            skipButton.SetActive(true);
        }
    }


    private void VideoFinished(VideoPlayer vp)
    {
        LoadGameplay();
    }


    public void SkipVideo()
    {
        LoadGameplay();
    }


    private void LoadGameplay()
    {
        if (hasFinished)
            return;

        hasFinished = true;

        SceneManager.LoadScene(gameplaySceneName);
    }
}
