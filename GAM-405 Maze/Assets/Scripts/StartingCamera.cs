using UnityEngine;
using Unity.Cinemachine;
using System.Collections;
using Unity.VisualScripting;

public class StartingCamera : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ChangePriority());
    }

    [SerializeField] CameraControl cc;
    [SerializeField] PlayerRotate pr;

    private IEnumerator ChangePriority()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<CinemachineCamera>().Priority = 5;


        StartCoroutine(EnablePlayer());
    }

    private IEnumerator EnablePlayer()
    {
        yield return new WaitForSeconds(3f);
        cc.isActive = true;
        pr.isActive = true;

        //GetComponent<Light>().color = Color.red;
    }
}
