using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Character Basic Movement Component script
public class BasicMovement : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D rigidbody2D;

    private void Awake() {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start() {

    }
    private void FixedUpdate() {
        Vector3 _movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        
        animator.SetFloat("Horizontal", _movement.x);
        animator.SetFloat("Vertical", _movement.y);
        animator.SetFloat("Magnitude", _movement.magnitude);

        rigidbody2D.velocity = _movement * 100.0f * Time.deltaTime;
    }
}