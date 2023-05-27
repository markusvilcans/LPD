using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public GameObject backgroundMusicObject;
    private AudioSource backgroundMusicAudioSource;

    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void StopGame(){
        Application.Quit();
    }

    public void ToggleBackgroundMusic()
    {
        backgroundMusicAudioSource.enabled = !backgroundMusicAudioSource.enabled;
    }
}
