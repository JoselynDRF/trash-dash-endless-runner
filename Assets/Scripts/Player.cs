using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator animator;
    private Rigidbody rb;
    private int runSpeed = 10;

    void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.Play("runStart");
    }

    void Update() {
      rb.velocity = Vector3.forward * runSpeed;
    }
}
