using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Lives")]
    public int maxLives = 3;
    public int lives;

    [Header("Scenes (names must match Build Profile)")]
    public string menuScene = "Menu";
    public string level1Scene = "Level1";
    public string level2Scene = "Level2";
    public string finalScene = "Final";


    [Header("Score")]
    public int score = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        lives = maxLives;
    }

    // Chame isso quando a bola cair no DeathZone
  

    public void LoseLife(){
        lives--;

        if (lives <= 0){
                // aí sim pode voltar pro menu (zera tudo)
            ResetGameToMenu();
        }
        else{
                // NÃO recarrega cena!
            RespawnBallOnly();
        }
    }

    private void RespawnBallOnly(){
        var ball = FindFirstObjectByType<BallControl>();
        if (ball != null) ball.ResetBallToPaddle();
    }

    // Chame isso quando não existir mais blocos na fase
    public void CheckWinCondition()
    {
        // Se não existir nenhum bloco com tag "Brick", passou de fase
        if (GameObject.FindGameObjectsWithTag("Brick").Length == 0)
        {
            GoNextLevel();
        }
    }

    private void GoNextLevel()
    {
        string current = SceneManager.GetActiveScene().name;

        if (current == level1Scene)
            SceneManager.LoadScene(level2Scene);
        else if (current == level2Scene)
            SceneManager.LoadScene(finalScene);
        else
            SceneManager.LoadScene(menuScene);
    }

    // Se quiser um botão no Menu pra começar:
    public void StartGame()
    {
        lives = maxLives;
        score = 0;
        SceneManager.LoadScene(level1Scene);
    }

    private void ResetGameToMenu(){
        lives = maxLives;
        score = 0;
        SceneManager.LoadScene(menuScene);
    }

    public void AddScore(int amount){
        score += amount;
    }
}