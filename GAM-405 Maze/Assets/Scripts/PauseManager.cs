using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    public bool paused;
    public GameObject pauseMenuUI;

    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
            Cursor.visible = pauseMenuUI.activeSelf;
            Cursor.lockState = pauseMenuUI.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene("StartMenu");
        Debug.Log("Quitting Game");
    }
}
