using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject beginCanvas;

    void Start(){
        startCanvas.SetActive(true);
        beginCanvas.SetActive(false);
    }

    public void BeginGame()
    {
        startCanvas.SetActive(false);
        beginCanvas.SetActive(true);
    }

    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void StopGame(){
        Application.Quit();
    }
}
