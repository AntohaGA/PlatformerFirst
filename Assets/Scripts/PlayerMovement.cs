using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private const float CheckGroundDistant = 0.1f;

    [SerializeField] private float _speed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D _rigidBody;
    private Animator _animator;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckGround();
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
        bool isGrounded;

        if (Physics2D.Raycast(transform.position, -Vector2.up, CheckGroundDistant).collider != null)
        {
            isGrounded = true;
            _animator.SetBool("isJump", false);
        }
        else
        {
            isGrounded = false;
            _animator.SetBool("isJump", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}