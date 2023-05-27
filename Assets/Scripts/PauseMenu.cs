using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    private InputAction escapeAction;

    private void OnEnable()
    {
        // Enable the input action
        escapeAction.Enable();
    }

    private void OnDisable()
    {
        // Disable the input action
        escapeAction.Disable();
    }

    private void Awake()
    {
        // Create a new input action for the Escape key
        escapeAction = new InputAction("Escape");
        escapeAction.AddBinding("<Keyboard>/escape");
        escapeAction.performed += ctx => HandleEscape();
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
        // Hide and lock the cursor at the beginning
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void HandleEscape()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        // Show and unlock the cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        // Hide and lock the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
