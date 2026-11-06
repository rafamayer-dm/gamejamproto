using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Ignora a colisão se bater no próprio jogador ou arma
        if (collision.gameObject.GetComponentInParent<PlayerMovement>() != null)
        {
            return;
        }

        Balloon balloon = collision.gameObject.GetComponentInParent<Balloon>();

        if (balloon != null)
        {
            balloon.Pop();
        }

        // Destrói a bala ao bater em qualquer coisa
        Destroy(gameObject);
    }
}