using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball")) return;

        // perde vida
        GameManager.Instance.LoseLife();

        // reseta a bola em cima do paddle
        BallControl ball = other.GetComponent<BallControl>();
        if (ball != null)
            ball.ResetToPaddle();
    }
}