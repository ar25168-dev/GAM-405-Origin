using System.Runtime.CompilerServices;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;


    private void OnEnable()
    {
        EventManager.TogglePause += TogglePauseMenu;
    }

    private void OnDisable()
    {
        EventManager.TogglePause -= TogglePauseMenu;
    }


    private void TogglePauseMenu(bool pause)
    {
        pauseMenu.SetActive(pause);
    }
}
