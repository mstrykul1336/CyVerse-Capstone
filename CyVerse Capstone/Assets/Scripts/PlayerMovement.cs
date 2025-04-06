using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public RuntimeAnimatorController walkNorth;
    public RuntimeAnimatorController walkSouth;
    public RuntimeAnimatorController walkEast;
    public RuntimeAnimatorController walkWest;
    public RuntimeAnimatorController idleController;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get input from WASD keys
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right Arrow
        moveInput.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down Arrow
        moveInput.Normalize(); // Prevents diagonal movement from being faster

        // Set animation controllers based on movement direction
        if (moveInput.y > 0)
            animator.runtimeAnimatorController = walkNorth;
        else if (moveInput.y < 0)
            animator.runtimeAnimatorController = walkSouth;
        else if (moveInput.x > 0)
            animator.runtimeAnimatorController = walkEast;
        else if (moveInput.x < 0)
            animator.runtimeAnimatorController = walkWest;
        else
            animator.runtimeAnimatorController = idleController; // Default idle animation when not moving
    }

    void FixedUpdate()
    {
        // Apply movement to the Rigidbody
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
