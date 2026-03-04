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

    }

    void Update()
    {

        float dir = 0f;
        if (Input.GetKey(moveRight)) dir = 1f;
        else if (Input.GetKey(moveLeft)) dir = -1f;


        Vector2 vel = rb2d.linearVelocity;
        vel.x = dir * speed;
        vel.y = 0f; 
        rb2d.linearVelocity = vel;


        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -limitX, limitX);
        transform.position = pos;
    }
}