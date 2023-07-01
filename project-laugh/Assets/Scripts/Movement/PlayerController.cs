using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// Character Basic Movement Component script
public class PlayerController : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private GameEnv gameEnv;

    [Header("Status variable")]
    private float speed = 0.0f;
    private Controller.State state;

    [Header("Move variable")]
    public Vector3 direction;
    public Vector3 moveDirection;
    public Vector3 mousePosition;
    public Vector3 mouseVector;
    public float mouseDistance;

    [Header("Attack variable")]
    private GameObject attackArea;
    private bool attacking = false;
    private float timeToAttack = 0.25f;

    private void Awake() {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        gameEnv = FindObjectOfType<GameEnv>();
    }
    private void Start() {
        InitStatus();
        InitObject();
    }
    private void Update() {
        GetInput();
    }
    private void FixedUpdate() {
        rigidbody2D.velocity = direction * speed * Time.deltaTime;
    }
    public void InitStatus() {
        speed = 2.0f * gameEnv.characterMoveSpeed;
        state = Controller.State.idle;
    }
    public void InitObject() {
        attackArea = transform.GetChild(0).gameObject;
    }
    public void GetInput() {
        // Mouse input varaible
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // position of cursor in world coordinate
        mousePosition.z = transform.position.z;
        mouseVector = (mousePosition - transform.position).normalized;
        mouseDistance = Vector3.Distance(transform.position, mousePosition);

        if (state == Controller.State.idle || state == Controller.State.move) {
            direction = Vector3.zero;
            state = Controller.State.idle;

            if(Input.GetKey(KeyCode.W)) { // Move up
                direction = direction + Vector3.up;
                SetMoveDirection(0.0f, 1.0f, 0.0f);
                state = Controller.State.move;
            }
            if (Input.GetKey(KeyCode.S)) { // Move down
                direction = direction + Vector3.down;
                SetMoveDirection(0.0f, -1.0f, 0.0f);
                state = Controller.State.move;
            }
            if (Input.GetKey(KeyCode.D)) { // Move right
                direction = direction + Vector3.right;
                SetMoveDirection(1.0f, 0.0f, 0.0f);
                state = Controller.State.move;
            }
            if (Input.GetKey(KeyCode.A)) { // Move left
                direction = direction + Vector3.left;
                SetMoveDirection(-1.0f, 0.0f, 0.0f);
                state = Controller.State.move;
            }

            // animator update
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);

            if (state == Controller.State.move) {
                animator.SetFloat("Magnitude", 1.0f);
            }
            else {
                rigidbody2D.velocity = new Vector2(0, 0);
                animator.SetFloat("Magnitude", 0.0f);
            }

            if(Input.GetKeyDown(KeyCode.Mouse0)) {
                Attack();
            }
        }

    }// 키보드와 마우스로부터 플레이어의 방향을 받아오는 함수
    private void Attack() {
        attacking = true;
        attackArea.SetActive(attacking);
        StartCoroutine(AttackDone());
    }
    IEnumerator AttackDone() {
        yield return new WaitForSeconds(timeToAttack);
        attacking = false;
        attackArea.SetActive(attacking);
    }
    public void SetMoveDirection(float _x, float _y, float _z) {
        moveDirection.x = _x;
        moveDirection.y = _y;
        moveDirection.z = _z;
    }

}