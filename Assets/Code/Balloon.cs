using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    public Pig pig;

    private void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    public void Pop()
    {
        Debug.Log("BALAO ESTOUROU");

        pig.Fall();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Balão detectou: " + other.name);
    }
}