using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
private void OnTriggerEnter(Collider other)
{
    Debug.Log("BALA ACERTOU: " + other.name);
    Balloon balloon = other.GetComponentInParent<Balloon>();

    if (balloon != null)
    {
        Debug.Log("BALAO ACERTADO");
        balloon.Pop();
    }

    Destroy(gameObject);
}
}