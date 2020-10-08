using UnityEngine;

public class Player : MonoBehaviour {

    public float runSpeed = 10f;
    public float laneChangeSpeed = 10f;
    public float jumpLength = 7.5f;
    public float jumpHeight = 1f;
    public float jumpSpeed = 5f;

    private Animator animator;
    private Rigidbody rb;
    private Vector3 targetPosition;
    private float jumpStart;
    private bool isJumping = false;

    void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.Play("runStart");
    }

    void Update() {
        MoveCharacter();
    }

    void FixedUpdate() {
        rb.velocity = Vector3.forward * runSpeed;
    }

    void MoveCharacter() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) ChangeLane(-1);
        else if (Input.GetKeyDown(KeyCode.RightArrow)) ChangeLane(1);
        else if (Input.GetKeyDown(KeyCode.UpArrow)) Jump();

        HandleJump();

        Vector3 newPosition = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        transform.localPosition = Vector3.MoveTowards(transform.position, newPosition, laneChangeSpeed * Time.deltaTime);
    }

    void ChangeLane(int direction) {
        float targetLane = targetPosition.x + direction;

        if (targetLane >= -1f && targetLane <= 1f) {
            targetPosition.x = targetLane;
        }
    }

    void Jump() {
        if (!isJumping) {
            isJumping = true;
            jumpStart = transform.position.z;
            animator.SetBool("Jumping", true);
            animator.SetFloat("JumpSpeed", runSpeed / jumpLength);
        }
    }

    void HandleJump() {
        if (isJumping) {
            float ratio = (transform.position.z - jumpStart) / jumpLength;

            if (ratio >= 1) {
                isJumping = false;
                animator.SetBool("Jumping", false);
            } else {
                targetPosition.y = Mathf.Sin(ratio * Mathf.PI) * jumpHeight;
            }
        } else {
            targetPosition.y = Mathf.MoveTowards(targetPosition.y, 0, jumpSpeed * Time.deltaTime);
        }
    }
}
