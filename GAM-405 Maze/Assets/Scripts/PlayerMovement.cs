using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{

    public InputActionReference moveAction;


    public float moveSpeed = 5f;


    [SerializeField] private Vector2 moveInput;


    [SerializeField] private Rigidbody rb;


    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
     moveInput = moveAction != null ? moveAction.action.ReadValue<Vector2>() : Vector2.zero;
    }


    void OnEnable()
    {
        moveAction?.action.Enable();
    }


    void OnDisable()
    {
        moveAction?.action.Disable();
    }

    private void HandleMovement()
    {
        Vector3 inputDir = new Vector3(moveInput.x, 0f, moveInput.y);
        if (inputDir.sqrMagnitude > 1f) inputDir.Normalize();

        Vector3 move = transform.TransformDirection(inputDir) * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + move);
    }

    void FixedUpdate()
    {
        HandleMovement();
    }
}