using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroController : MonoBehaviour
{
    [Header("Configurações")]
    public VideoPlayer videoPlayer;
    public string gameplaySceneName = "GameplayScene";

    private bool hasFinished = false;

    private void Start()
    {
        // Quando o vídeo terminar chama essa função
        videoPlayer.loopPointReached += VideoFinished;

        // Começa o vídeo
        videoPlayer.Play();
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
