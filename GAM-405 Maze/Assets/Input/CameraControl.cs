using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraControl : MonoBehaviour

{
    [SerializeField] private float sensetivity = 5f;
    [SerializeField] private Vector2 clampValue = new Vector2(-90f, 90f);

    private float xRotation;
    public Transform playerCamera;



    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensetivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensetivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
