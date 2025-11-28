using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.AI;
using JetBrains.Annotations;

public class TorchMechanic : MonoBehaviour
{
    public GameObject torch;
    public bool torchActive;
    public SkeletonAI skeletonAI;
    public bool isHit;

    public float rayDistance = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        torch.SetActive(false);
        isHit = false;
    }

    public Transform FirePoint;

    void Update()
    {
        TurnTorchOn();
    }

    public void Shooting()
    {

        RaycastHit hit;

        if (Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            SkeletonAI skeletonAI = hit.collider.gameObject.GetComponent<SkeletonAI>();



            if (hit.collider.CompareTag("Enemy") && isHit == false && torchActive == true)
            {
                Debug.Log(hit.collider.gameObject.tag);
                skeletonAI.agent.isStopped = true;
                isHit = true;

                StartCoroutine(skeletonAI.stuntimer());

            }
            
            
            if (isHit == true && torchActive == false)
            {
                skeletonAI.agent.isStopped = false;
                isHit = false;

            }
        }
    }
    


    public void TurnTorchOn()
    {

        //turning torch on
        if (Input.GetKeyDown(KeyCode.Q) &&  torchActive == false)
        {
            torchActive = true;
            torch.SetActive(torchActive);
            
        }
        else if(Input.GetKeyDown(KeyCode.Q) &&  torchActive == true)
        {
            torchActive = false;
            torch.SetActive(torchActive);
           
        }

        Shooting();

        //shoot raycast from camera
        //if raycast hits enemy - gameobject tagged as enemy
        // make them stop moving agent.stop():

       

    }

}
