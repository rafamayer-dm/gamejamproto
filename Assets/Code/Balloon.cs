using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    public Pig pig;

    [Header("Pontuação")]
    public int pointsValue = 10; // Quantidade de pontos que este balão vale

    private void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    public void Pop()
    {
        // 1. Solta o porco para ele cair pela física
        if (pig != null)
        {
            pig.transform.SetParent(null);
            pig.Fall();
        }

        // 2. Envia os pontos para o ScoreManager (se ele existir na cena)
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(pointsValue);
        }

        // 3. Destrói o balão vazio
        Destroy(gameObject);
    }
}