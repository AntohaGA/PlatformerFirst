using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private static int s_hit = Animator.StringToHash("hit");
    private static int s_attack = Animator.StringToHash("attack");
    private static int s_speed = Animator.StringToHash("speed");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void RunAnimation()
    {
        _animator.SetFloat(s_speed, 1);
    }

    public void HitAnimation()
    {
        _animator.SetTrigger(s_hit);
    }

    public void AttackAnimation()
    {
        _animator.SetFloat(s_speed, 0);
        _animator.SetBool(s_attack, true);
    }

    public void StopAttackAnimation()
    {
        _animator.SetBool(s_attack, false);
        _animator.SetFloat(s_speed, 1);
    }
}