using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public class Health : MonoBehaviour, IDamagable
{
    private PlayerAnimator _playerAnimator;

    public float Count { get; private set; } = 100;

    private void Awake()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    public void AddHealth(AidKit health)
    {
        Count += health.CountHealth;
        Debug.Log(Count);
    }

    public void TakeDamage(float damage)
    {
        _playerAnimator.TakeHitAnumation();

        if (Count > 0 && damage > 0)
            Count -= damage;

        Debug.Log(Count);
    }
}