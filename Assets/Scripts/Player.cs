using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] bool isLeftPlayer;
    [SerializeField][Range(1.0f, 10.0f)] float playerSpeed = 6.0f;

    Rigidbody2D rb;
    float y = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isLeftPlayer)
        {
            y = ((Input.GetKey(KeyCode.W) ? 1.0f : 0.0f) + (Input.GetKey(KeyCode.S) ? -1.0f : 0.0f)) * playerSpeed;
        }
        else
        {
            y = ((Input.GetKey(KeyCode.UpArrow) ? 1.0f : 0.0f) + (Input.GetKey(KeyCode.DownArrow) ? -1.0f : 0.0f)) * playerSpeed;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(0.0f, y) * Time.deltaTime);
    }
}
