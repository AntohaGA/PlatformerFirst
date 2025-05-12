using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private static int s_speed = Animator.StringToHash("speed");
    private static int s_isJump = Animator.StringToHash("isJump");

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
        _animator.SetBool(s_isJump, false);
    }

    public void JumpAnimation()
    {
        _animator.SetBool(s_isJump, true);
    }
}