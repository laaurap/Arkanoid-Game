using UnityEngine;

public class SideWalls : MonoBehaviour
{
    [Header("Optional: prevents the ball from getting stuck with too small X/Y velocity")]
    public float minComponentSpeed = 0.5f;

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (!hit.gameObject.CompareTag("Ball")) return;

        Rigidbody2D rb = hit.gameObject.GetComponent<Rigidbody2D>();
        if (rb == null) return;

        // Unity 6: use linearVelocity
        Vector2 v = rb.linearVelocity;

        // Garantia: não deixar componente X ou Y ficar muito pequeno (evita bola “reta demais” ou travada)
        if (Mathf.Abs(v.x) < minComponentSpeed)
            v.x = Mathf.Sign(v.x == 0 ? Random.Range(-1f, 1f) : v.x) * minComponentSpeed;

        if (Mathf.Abs(v.y) < minComponentSpeed)
            v.y = Mathf.Sign(v.y == 0 ? 1f : v.y) * minComponentSpeed;

        // Mantém o mesmo módulo (velocidade) e só ajusta direção
        float speed = rb.linearVelocity.magnitude;
        rb.linearVelocity = v.normalized * speed;
    }
}