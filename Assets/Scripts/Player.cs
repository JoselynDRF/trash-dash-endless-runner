using UnityEngine;

public class Player : MonoBehaviour {

    public float runSpeed = 10f;
    public float laneChangeSpeed = 10f;

    private Animator animator;
    private Rigidbody rb;
    private Vector3 targetPosition;
    private int currentLane = 0;

    void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.Play("runStart");
    }

    void Update() {
      MoveCharacter();
    }

    void MoveCharacter() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) ChangeLane(-1);
        else if (Input.GetKeyDown(KeyCode.RightArrow)) ChangeLane(1);

        Vector3 newPosition = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        transform.localPosition = Vector3.MoveTowards(transform.position, newPosition, laneChangeSpeed * Time.deltaTime);
    }

    void ChangeLane(int direction) {
        int targetLane = currentLane + direction;

        if (targetLane >= -1 && targetLane <= 1) {
            targetPosition = new Vector3(targetLane, 0, 0);
            currentLane = targetLane; 
        }
    }

    void FixedUpdate() {
        rb.velocity = Vector3.forward * runSpeed;
    }
}
