using UnityEngine;

public class Brick : MonoBehaviour
{
    public int points = 10;

    public void Break()
    {
        GameManager.Instance.AddScore(points);
        Destroy(gameObject);
    }
}