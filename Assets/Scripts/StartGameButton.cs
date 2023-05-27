using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void StartGame(string scene){
        SceneManager.LoadScene(scene);
    }

    public void StopGame(){
        Application.Quit();
    }
}
