using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private static int s_speed = Animator.StringToHash("speed");
    private static int s_isJump = Animator.StringToHash("isJump");
    private static int s_Attack = Animator.StringToHash("attack");
    private static int s_isFall = Animator.StringToHash("isFall");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move(float direction)
    {
        _animator.SetFloat(s_speed, Mathf.Abs(direction));
    }

    public void LandAnimation()
    {
        _animator.SetBool(s_isFall, false);
        _animator.SetBool(s_isJump, false);
    }

    public void JumpAnimation()
    {
        _animator.SetBool(s_isJump, true);
    }

    public void AttackAnimation()
    {
        _animator.SetTrigger(s_Attack);
    }

    public void FallAnimation()
    {
        _animator.SetBool(s_isFall, true);
    }
}