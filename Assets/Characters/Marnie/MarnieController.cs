using UnityEngine;

public class MarnieController : MonoBehaviour
{
    public float moveSpeed = 4f;

    Rigidbody2D rb;
    Animator anim;

    float moveX;
    float moveY;

    float lastMoveX = 1; // default facing right
    float lastMoveY = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Read NEW input system
        moveX = UnityEngine.InputSystem.Keyboard.current == null ? 0 : 
                (UnityEngine.InputSystem.Keyboard.current.aKey.isPressed ? -1 :
                UnityEngine.InputSystem.Keyboard.current.dKey.isPressed ? 1 : 0);

        moveY = UnityEngine.InputSystem.Keyboard.current == null ? 0 :
                (UnityEngine.InputSystem.Keyboard.current.sKey.isPressed ? -1 :
                UnityEngine.InputSystem.Keyboard.current.wKey.isPressed ? 1 : 0);

        Vector2 move = new Vector2(moveX, moveY).normalized;

        rb.linearVelocity = move * moveSpeed;

        bool isMoving = move.magnitude > 0.1f;
        anim.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            anim.SetFloat("moveX", moveX);
            anim.SetFloat("moveY", moveY);

            lastMoveX = moveX;
            lastMoveY = moveY;
        }
        else
        {
            anim.SetFloat("moveX", lastMoveX);
            anim.SetFloat("moveY", lastMoveY);
        }
    }
}
