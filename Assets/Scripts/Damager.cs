using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Damager : MonoBehaviour
{
    private CircleCollider2D _hitArea;
    private Collider2D[] results;

    private void Awake()
    {
        _hitArea = GetComponent<CircleCollider2D>();
        results = new Collider2D[5];
    }
    public void Hit(float damage)
    {
        ContactFilter2D filter = new ContactFilter2D();
        int countOverlap = _hitArea.Overlap(filter.NoFilter(), results);

        for (int i = 0; i < countOverlap; i++)
        {
            if (results[i].TryGetComponent(out IDamagable component))
            {
                component.TakeDamage(damage);
            }
        }
    }
}