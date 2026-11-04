using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform target;

    public float distance = 4f;
    public float height = 1.5f;

    public LayerMask obstacleLayers;

    void LateUpdate()
    {
        Vector3 origin = target.position + Vector3.up * height;

        Vector3 desiredPosition =
            origin - target.forward * distance;

        RaycastHit hit;

        if (Physics.Linecast(origin, desiredPosition,
            out hit, obstacleLayers))
        {
            transform.position =
                hit.point + hit.normal * 0.2f;
        }
        else
        {
            transform.position = desiredPosition;
        }

        transform.LookAt(origin);
    }
}
