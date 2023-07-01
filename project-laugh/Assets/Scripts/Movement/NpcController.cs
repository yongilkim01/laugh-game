using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private GameEnv gameEnv;

    [Header("Status")]
    private Vector3 direction;
    private float speed;

    private void Awake() {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        gameEnv = FindObjectOfType<GameEnv>();
    }
    private void Start() {
        InitStatus();
        StartCoroutine(NPCDirection());
    }
    private void FixedUpdate() {
        Move();
    }
    private void InitStatus() {
        speed = gameEnv.characterMoveSpeed * 2.0f;
    }

    IEnumerator NPCDirection() {
        while (true) {
            direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f);

            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Magnitude", direction.magnitude);

            yield return new WaitForSeconds(3.0f);
        }
    }
    public void Move() {
        rigidbody2D.velocity = direction * speed * Time.deltaTime;
    }
}
