using UnityEngine;

public class DreamMarnieMovement : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    public static DreamMarnieMovement instance;
    public bool locked = false;

    void Awake()
    {
        instance = this;
    }   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (locked) return;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(x, y).normalized;
        rb.linearVelocity = move * speed;
    }
}
