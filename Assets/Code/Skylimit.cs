using UnityEngine;

public class Skylimit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balloon"))
        {
            Debug.Log("funcionou");
            Destroy(other.gameObject);
        }
        
    Debug.Log("Entrou: " + other.name);

    Debug.Log("Tag: " + other.tag);
    }
}

