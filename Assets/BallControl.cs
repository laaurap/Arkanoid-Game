using UnityEngine;

public class BallControl : MonoBehaviour
{
    [Header("Launch / Speed")]
    public float speed = 8f;
    public KeyCode launchKey = KeyCode.Space;

    [Header("Attach to Paddle (before launch / after reset)")]
    public Transform paddle;
    public Vector3 offset = new Vector3(0f, 0.5f, 0f);

    private Rigidbody2D rb;
    private bool launched = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Recomendado no Rigidbody2D da bola:
        // Gravity Scale = 0, Linear Damping = 0, Collision Detection = Continuous
        ResetToPaddle();
    }

    void Update()
    {
        if (!launched)
        {
            // Segue o paddle antes do lançamento
            if (paddle != null)
                transform.position = paddle.position + offset;

            if (Input.GetKeyDown(launchKey))
                Launch();
        }
        else
        {
            // Mantém velocidade constante (evita “morrer” e ficar lenta)
            Vector2 v = rb.linearVelocity;
            if (v.sqrMagnitude > 0.0001f)
                rb.linearVelocity = v.normalized * speed;
        }
    }

    private void Launch()
    {
        launched = true;

        // Direção inicial com leve variação no X
        Vector2 dir = new Vector2(Random.Range(-0.8f, 0.8f), 1f).normalized;
        rb.linearVelocity = dir * speed;
    }

    public void ResetToPaddle()
    {
        launched = false;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        if (paddle != null)
            transform.position = paddle.position + offset;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Quebra blocos
        if (col.gameObject.CompareTag("Brick"))
        {
            Brick brick = col.gameObject.GetComponent<Brick>();
            if (brick != null) brick.Break();
            else Destroy(col.gameObject);
        }

        // Rebote estilo Arkanoid no paddle
        if (col.collider.CompareTag("Player"))
        {
            float hit = transform.position.x - col.transform.position.x;
            float halfWidth = col.collider.bounds.size.x / 2f;

            float x = Mathf.Clamp(hit / halfWidth, -1f, 1f);
            Vector2 dir = new Vector2(x, 1f).normalized;

            rb.linearVelocity = dir * speed;
        }
    }
}