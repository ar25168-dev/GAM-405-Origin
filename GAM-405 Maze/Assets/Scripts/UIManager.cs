using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject mainmenuPanel;

    public GameObject pausePanel;

    public bool isPaused = false;

    void Update()
    {
        PauseGameUsingEsc();
    }

    public void PauseGameUsingEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1f;
                Debug.Log("Resuming Game");
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                pausePanel.SetActive(false);
                isPaused = false;
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Resuming Game");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pausePanel.SetActive(false);
        isPaused = false;
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    void Start()
    {
       // mainmenuPanel.SetActive(true);
       // settingsPanel.SetActive(false);
    }



    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        mainmenuPanel.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainmenuPanel.SetActive(true);
    }
}
