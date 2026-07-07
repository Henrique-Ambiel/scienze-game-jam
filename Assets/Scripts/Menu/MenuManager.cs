using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string userDataName;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject configPanel;


    //Botão que vai para tela de dados do usuário
    public void Game()
    {
        SceneManager.LoadScene(userDataName);
        Debug.Log("Jogo Iniciado");
    }

    //Botão que fecha o jogo
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo");
    }
}