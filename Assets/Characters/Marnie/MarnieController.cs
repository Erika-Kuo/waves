using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MarnieSimpleController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 3.5f;

    [Header("Side sprites (required)")]
    public Sprite sideIdle;                  // assign your side idle sprite
    public Sprite[] sideWalkFrames;          // assign your side walk frames in order
    public float walkFrameRate = 8f;         // frames per second for walking

    [Header("Optional (if you later have up/down sprites)")]
    public Sprite upIdle;
    public Sprite[] upWalkFrames;
    public Sprite downIdle;
    public Sprite[] downWalkFrames;

    private Rigidbody2D rb;
    private SpriteRenderer spr;
    private Vector2 move;
    private float walkTimer;
    private int walkIndex;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();

        // safety: if no up/down provided, default to side sprites
        if (upIdle == null) upIdle = sideIdle;
        if (downIdle == null) downIdle = sideIdle;
        if (upWalkFrames == null || upWalkFrames.Length == 0) upWalkFrames = sideWalkFrames;
        if (downWalkFrames == null || downWalkFrames.Length == 0) downWalkFrames = sideWalkFrames;
    }

    void Update()
    {
        // read input
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        move = move.normalized;

        // animate sprite depending on movement
        if (move.sqrMagnitude > 0.001f)
        {
            AnimateWalking(move);
        }
        else
        {
            // idle sprite based on last direction faced
            SetIdleSprite();
            walkTimer = 0f;
            walkIndex = 0;
        }
    }

    void FixedUpdate()
    {
        // move using MovePosition for smooth kinematic-like movement
        Vector2 newPos = rb.position + move * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }

    // remember last horizontal direction so idle faces correct way
    private Vector2 lastDir = Vector2.down; // default facing down

    void AnimateWalking(Vector2 dir)
    {
        // choose which frame set to use (vertical or horizontal)
        Sprite[] frames = sideWalkFrames;

        // prefer vertical if vertical movement stronger than horizontal
        if (Mathf.Abs(dir.y) > Mathf.Abs(dir.x))
        {
            if (dir.y > 0) frames = upWalkFrames;
            else frames = downWalkFrames;
        }
        else
        {
            frames = sideWalkFrames;
        }

        // step through frames
        walkTimer += Time.deltaTime;
        float frameTime = 1f / Mathf.Max(0.01f, walkFrameRate);
        if (walkTimer >= frameTime && frames.Length > 0)
        {
            walkTimer -= frameTime;
            walkIndex = (walkIndex + 1) % frames.Length;
            spr.sprite = frames[walkIndex];
        }

        // flip sprite when moving left
        if (dir.x < -0.01f) spr.flipX = true;
        else if (dir.x > 0.01f) spr.flipX = false;

        // set last direction
        if (dir.sqrMagnitude > 0.01f) lastDir = dir;
    }

    void SetIdleSprite()
    {
        // decide which idle to use based on lastDir
        if (Mathf.Abs(lastDir.y) > Mathf.Abs(lastDir.x))
        {
            if (lastDir.y > 0) spr.sprite = upIdle;
            else spr.sprite = downIdle;
        }
        else
        {
            spr.sprite = sideIdle;
        }

        // flip if last faced left
        if (lastDir.x < -0.01f) spr.flipX = true;
        else if (lastDir.x > 0.01f) spr.flipX = false;
    }
}
