using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball")) return;

        GameManager.Instance.LoseLife();

        BallControl ball = other.GetComponent<BallControl>();
        if (ball != null)
            ball.ResetToPaddle();
    }
}