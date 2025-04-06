using UnityEngine;

public class MoveSpriteWest : MonoBehaviour
{
    public Vector2 targetPosition;
    public float speed = 2f;
       public float stopDistance = 0.05f;

    private Animator animator;
    public RuntimeAnimatorController walkWest;
    public RuntimeAnimatorController idle;
    private bool isMoving = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        // Optional: Automatically start moving on play
        //StartMoving();
    }

    void Update()
    {
        if (isMoving)
        {
            Vector2 currentPosition = transform.position;
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
            transform.position = newPosition;

            if (Vector2.Distance(newPosition, targetPosition) <= stopDistance)
            {
                isMoving = false;
                animator.runtimeAnimatorController = idle;
                Debug.Log("Arrived at target position.");
            }
        }
    }

    public void StartMoving()
    {
        // Only trigger animation if moving west
        if (targetPosition.x < transform.position.x)
        {
            animator.runtimeAnimatorController = walkWest;
        }

        isMoving = true;
    }
}
