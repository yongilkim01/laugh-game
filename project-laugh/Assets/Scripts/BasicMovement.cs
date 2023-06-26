using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Character Basic Movement Component script
public class BasicMovement : MonoBehaviour {

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void Start() {

    }
    private void Update() {
        Vector3 _movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        
        animator.SetFloat("Horizontal", _movement.x);
        animator.SetFloat("Vertical", _movement.y);
        animator.SetFloat("Magnitude", _movement.magnitude);

        transform.position = transform.position + _movement * Time.deltaTime;
    }
}