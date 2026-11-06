using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("Pontuação")]
    public TextMeshProUGUI scoreText;
    private int score = 0;

    [Header("Vidas")]
    public TextMeshProUGUI livesText;
    public GameObject gameOverText;
    private int lives = 4;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        // Garante que o jogo roda na velocidade normal e esconde o Game Over
        Time.timeScale = 1f;
        if (gameOverText != null) gameOverText.SetActive(false);

        UpdateScoreUI();
        UpdateLivesUI();
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreUI();
    }

    // Função nova que o teto vai chamar
    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateLivesUI();

            if (lives <= 0)
            {
                TriggerGameOver();
            }
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null) scoreText.text = "Pontos: " + score;
    }

    private void UpdateLivesUI()
    {
        if (livesText != null) livesText.text = "Vidas: " + lives;
    }

    private void TriggerGameOver()
    {
        // Mostra o texto de Game Over
        if (gameOverText != null) gameOverText.SetActive(true);

        // Congela o tempo do jogo
        Time.timeScale = 0f;

        // Destrava e mostra o rato para poder clicar em menus futuramente
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}