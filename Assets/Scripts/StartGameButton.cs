using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject beginCanvas;
    public GameObject tutorialCanvas;
    public GameObject tutorialCanvasTwo;
    public GameObject tutorialCanvasThree;
    public GameObject tutorialCanvasFour;

    void Start(){
        startCanvas.SetActive(true);
    }

    public void BeginGame()
    {
        startCanvas.SetActive(false);
        beginCanvas.SetActive(true);
    }

    public void ShowTutorial(){
        beginCanvas.SetActive(false);
        tutorialCanvas.SetActive(true);
    }

    public void ShowTutorialTwo(){
        tutorialCanvas.SetActive(false);
        tutorialCanvasTwo.SetActive(true);
    }

    public void ShowTutorialThree(){
        tutorialCanvasTwo.SetActive(false);
        tutorialCanvasThree.SetActive(true);
    }

    public void ShowTutorialFour(){
        tutorialCanvasThree.SetActive(false);
        tutorialCanvasFour.SetActive(true);
    }

    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void StopGame(){
        Application.Quit();
    }
}
