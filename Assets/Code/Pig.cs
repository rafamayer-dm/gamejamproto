using UnityEngine;

public class Pig : MonoBehaviour
{
    private Rigidbody rb;
    public AudioClip OinkPig;
    private AudioSource audioSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        // Enquanto preso ao balão
        rb.isKinematic = true;
    }

    public void Fall()
    {
        transform.SetParent(null);

        rb.isKinematic = false;
        rb.useGravity = true;
        
        if (audioSource != null && OinkPig != null)
        {
        audioSource.PlayOneShot(OinkPig);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject, 1f);
        }
    }
}