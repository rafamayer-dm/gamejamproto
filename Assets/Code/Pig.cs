using UnityEngine;

public class Pig : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // Enquanto preso ao balão
        rb.isKinematic = true;
    }

    public void Fall()
    {
        transform.SetParent(null);

        rb.isKinematic = false;
        rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject, 1f);
        }
    }
}