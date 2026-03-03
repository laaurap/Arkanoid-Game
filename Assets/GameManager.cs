using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 3;
    public int score = 0;

    [Header("Scene Names")]
    public string level1Name = "Level1";
    public string level2Name = "Level2";
    public string gameOverName = "GameOver";

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Só checa vitória nas cenas de jogo
        var scene = SceneManager.GetActiveScene().name;
        if (scene != level1Name && scene != level2Name) return;

        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        if (bricks.Length == 0)
        {
            if (scene == level1Name) SceneManager.LoadScene(level2Name);
            else if (scene == level2Name) SceneManager.LoadScene(gameOverName);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void LoseLife()
    {
        lives--;
        if (lives <= 0)
        {
            SceneManager.LoadScene(gameOverName);
        }
    }

    public void ResetGame()
    {
        lives = 3;
        score = 0;
        SceneManager.LoadScene(level1Name);
    }
}