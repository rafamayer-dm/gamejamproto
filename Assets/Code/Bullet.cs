using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<PlayerMovement>() != null) return;

        Balloon balloon = collision.gameObject.GetComponentInParent<Balloon>();

        if (balloon != null)
        {
            balloon.Pop();
        }
        else
        {
            // Se bater num balão e ele não estourar, este erro vai aparecer na Consola!
            Debug.LogWarning("Acertei o objeto [" + collision.gameObject.name + "] mas ele NÃO tem o script Balloon.cs anexado!");
        }

        Destroy(gameObject);
    }
}