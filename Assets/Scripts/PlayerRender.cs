using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Flipper))]
public class PlayerRender : MonoBehaviour
{
    private static readonly int speed = Animator.StringToHash(nameof(speed));
    private static readonly int isJump = Animator.StringToHash(nameof(isJump));

    private Animator _animator;
    private Flipper _flipper;

    private float _direction;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _flipper = GetComponent<Flipper>();
    }

    private void Update()
    {
        _flipper.SetDirection(_direction);
    }

    public void UpdateAnimation(float newSpeed, bool isJump)
    {
        _direction = newSpeed;
        _animator.SetFloat(speed, Mathf.Abs(newSpeed));
        _animator.SetBool(PlayerRender.isJump, isJump);
    }
}