using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public bool paused;

    public InputActionReference pauseInput;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseUI();
        }
        
    }

    public void TogglePause(InputAction.CallbackContext inputData)
    {
        Debug.Log("Did pausing work");
        paused = !paused;
        EventManager.InvokeTogglePause(paused);
    }

    public void TogglePauseUI()
    {
        paused = !paused;
        EventManager.InvokeTogglePause(paused);
    }
}
