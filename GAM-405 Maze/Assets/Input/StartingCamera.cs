using UnityEngine;
using Unity.Cinemachine;

public class StartingCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GetComponent<CinemachineCamera>().Priority = 5;
    }
}
