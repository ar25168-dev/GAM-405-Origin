using UnityEngine;
using UnityEngine.InputSystem;
public class CameraControl : MonoBehaviour

{
    [SerializeField] private float sensetivity = 5f;
    [SerializeField] private Vector2 clampValue = new Vector2(-90f, 90f);

    public InputActionReference cameraAction;


    void Update()
    {
        
    }
}
