using UnityEngine;

public class Skylimit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que bateu no teto faz parte de um balão
        Balloon balloon = other.GetComponentInParent<Balloon>();

        if (balloon != null)
        {
            // Tira 1 vida no ScoreManager
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.LoseLife();
            }

            // Destrói o balão e o porco para eles não ficarem presos no teto
            Destroy(balloon.gameObject);
        }
    }
}