using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform paddle;
    public Vector3 ballOffset = new Vector3(0, 0.5f, 0);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball")) return;

        GameManager.Instance.LoseLife();

        BallControl ball = other.GetComponent<BallControl>();
        if (ball != null)
            ball.ResetBall(paddle, ballOffset);
    }
}