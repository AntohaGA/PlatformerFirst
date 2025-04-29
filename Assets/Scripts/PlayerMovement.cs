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

    RaycastHit2D hit;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Physics2D.Raycast(transform.position, -Vector2.up, 0.1f).collider != null)
        {
            isGrounded = true;
            _animator.SetBool("isJump", false);
        }
        else
        {
            isGrounded = false;
            _animator.SetBool("isJump", true);
        }

        float deltaX = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        Vector2 movement = new Vector2(deltaX, _rigidBody.linearVelocity.y);

        _rigidBody.linearVelocity = movement;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        _animator.SetFloat("speed", Mathf.Abs(deltaX));

        if (Mathf.Approximately(deltaX, 0) != true)
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }
    }
}