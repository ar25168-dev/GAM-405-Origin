using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneLoader : MonoBehaviour
{
    public void pressedStartButton(InputAction.CallbackContext inputData)
    {
        LoadMainScene();
        Debug.Log("Input Reciebed");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("AttemptingLoad");
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            LoadMainScene();
        }
    }

}
