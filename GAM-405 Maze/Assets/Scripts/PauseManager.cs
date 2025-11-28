using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    public bool paused;
    public GameObject pauseMenuUI;

    public void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = paused ? 1 : 0;
            pauseMenuUI.SetActive(paused);
        }
    }

    

    public void Quit()
    {
        SceneManager.LoadScene("StartMenu");
        Debug.Log("Quitting Game");
    }
}
