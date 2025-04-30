using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D _rigidBody;
    private Animator _animator;

    private bool isGrounded;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckGround();
        Jump();
        Move();
    }

    private void Move()
    {
        float direction = Input.GetAxis("Horizontal");
        float distance = direction * _speed * Time.deltaTime;

        transform.Translate(distance * Vector2.right);
        _animator.SetFloat("speed", Mathf.Abs(direction));

        if (Mathf.Approximately(direction, 0) != true)
        {
            transform.localScale = new Vector3(Mathf.Sign(direction), 1, 1);
        }
    }

    private void CheckGround()
    {
        const float CheckGroundDistant = 0.1f;

        if (Physics2D.Raycast(transform.position, -Vector2.up, CheckGroundDistant).collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("isJump", true);
        }
        else
        {
            _animator.SetBool("isJump", false);
        }
    }
}