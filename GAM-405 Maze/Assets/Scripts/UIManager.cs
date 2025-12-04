using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject mainmenuPanel;

    public GameObject pausePanel;


    void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    { 
        
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            
        }
      

    }

    public void ResumeGame()
    {
      pausePanel.SetActive(false);
      Time.timeScale = 1f;
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
