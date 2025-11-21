using UnityEngine;
using UnityEngine.Rendering;

public class TorchMechanic : MonoBehaviour
{
    public GameObject torch;
    public bool torchActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public Transform FirePoint;

    void Update()
    {
        //turning torch on
        if (Input.GetKeyDown(KeyCode.Q))
        {
            torchActive = !torchActive;
        }

        torch.SetActive(torchActive);

        //shoot raycast from camera
        //if raycast hits enemy - gameobject tagged as enemy
        // make them stop moving agent.stop():

        Shooting();
    }

    public void Shooting()
    {
        RaycastHit hit;

        if (Physics.Raycast(FirePoint.position , transform.TransformDirection(Vector3.forward) , out hit , 100))
        {
            Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
    }

   
}
