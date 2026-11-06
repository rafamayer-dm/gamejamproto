using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
           RestartGame();
        }
    }

    public void RestartGame ()
    {
        Time.timeScale = 1f; // volta ao tempo normal

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}