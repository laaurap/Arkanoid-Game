using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text livesText;

    void Update()
    {
        if (GameManager.Instance == null) return;

        scoreText.text = "Score: " + GameManager.Instance.score;
        livesText.text = "Lives: " + GameManager.Instance.lives;
    }
}