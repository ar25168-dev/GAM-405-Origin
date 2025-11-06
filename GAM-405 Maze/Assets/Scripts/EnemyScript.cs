using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float detectionCutOff;

    private bool CanSeePlayer()
    {
        Vector3 myDir = transform.forward.normalized;
        Vector3 dirToPlayer = (player.transform.position - this.transform.position).normalized;

        if (Vector3.Dot(myDir, dirToPlayer) > detectionCutOff)
        {
            RaycastHit hitInfo;
            Physics.Raycast(this.transform.position, dirToPlayer, out hitInfo, 100f);

            if (hitInfo.collider.gameObject.gameObject == player)
            {
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            Debug.Log("CanSeePlayer");
        }
    }

}
