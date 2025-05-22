using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Damager : MonoBehaviour
{
    private CircleCollider2D _hitArea;
    private Collider2D[] _targetsInDmageArea;

    private void Awake()
    {
        _hitArea = GetComponent<CircleCollider2D>();
        _targetsInDmageArea = new Collider2D[5];
    }
    public void Hit(float damage)
    {
        ContactFilter2D filter = new ContactFilter2D();
        int countOverlap = _hitArea.Overlap(filter.NoFilter(), _targetsInDmageArea);

        for (int i = 0; i < countOverlap; i++)
        {
            if (_targetsInDmageArea[i].TryGetComponent(out IDamagable component))
                component.TakeDamage(damage);
        }
    }
}