using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private float _damage;

    [SerializeField] private int _layerForAttack;
    [SerializeField] private Vector3 _offsetAttack;
    [SerializeField] private float _radiusAttack;
    private Vector3 _centerOfCirleAttack;

    private void OnDrawGizmos()
    {
        _centerOfCirleAttack.x = _offsetAttack.x * transform.right.x;
        _centerOfCirleAttack.y = _offsetAttack.y;
        _centerOfCirleAttack += transform.position;

        Gizmos.DrawSphere(_centerOfCirleAttack, _radiusAttack);
    }

    public void Hit()
    {
        _centerOfCirleAttack.x = _offsetAttack.x * transform.right.x;
        _centerOfCirleAttack.y = _offsetAttack.y;
        _centerOfCirleAttack += transform.position;

        Collider2D[] results = Physics2D.OverlapCircleAll(_centerOfCirleAttack, _radiusAttack);

        for (int i = 0; i < results.Length; i++)
        {
           if (results[i].TryGetComponent(out IDamagable damagable)
                                                        && results[i].gameObject.layer == _layerForAttack && results[i].isTrigger == false)
                damagable.TakeDamage(_damage);
        }
    }
}