using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float sensetivity = 5f;

    public InputActionReference cameraAction;

    [SerializeField] public bool isActive;

    void Update()
    {
        if (!isActive)
        {
            return;
        }

        Vector2 cameraInput = new Vector2(0f, cameraAction.action.ReadValue<Vector2>().x);
        cameraInput *= sensetivity;
        transform.Rotate(cameraInput);
    }
}
