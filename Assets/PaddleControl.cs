using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;

    public float speed = 10f;
    public float limitX = 6.5f;   // limite no eixo X

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // Recomendado: Rigidbody2D = Kinematic (na Inspector)
        // Se estiver Dynamic, mantenha Gravity Scale = 0
    }

    void Update()
    {
        // 1) Decide direção com suas teclas
        float dir = 0f;
        if (Input.GetKey(moveRight)) dir = 1f;
        else if (Input.GetKey(moveLeft)) dir = -1f;

        // 2) Move via Rigidbody2D (Unity 6 usa linearVelocity)
        Vector2 vel = rb2d.linearVelocity;
        vel.x = dir * speed;
        vel.y = 0f; // Arkanoid não move em Y
        rb2d.linearVelocity = vel;

        // 3) Trava posição no X (pra não sair da tela)
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -limitX, limitX);
        transform.position = pos;
    }
}