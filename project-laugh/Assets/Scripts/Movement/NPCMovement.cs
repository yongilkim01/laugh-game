using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [Header("Component")]
    private Animator animator;
    private Rigidbody2D rigidbody2D;

    [Header("Status")]
    private Vector3 direction;

    private void Awake() {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start() {
        StartCoroutine(NPCDirection());
    }
    private void FixedUpdate() {
        Move();
    }

    IEnumerator NPCDirection() {
        while (true) {
            direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f);

            Debug.Log("Horizontal : " + direction.x);
            Debug.Log("Vertical : " + direction.y);

            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Magnitude", direction.magnitude);

            yield return new WaitForSeconds(3.0f);
        }
    }


    public void Move() {
        rigidbody2D.velocity = direction * 100.0f * Time.deltaTime;
    }
}
