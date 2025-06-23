using UnityEngine;

public class FinderClosestEnemy : MonoBehaviour
{
    public IDamagable GetClosestEnemy(Collider2D[] targets, float targetLayer)
    {
        float distant = 0;
        float minDistant = 0;
        IDamagable closestEnemy = null;

        foreach (Collider2D collider in targets)
        {
            if (collider.TryGetComponent(out IDamagable damagable)
                                         && collider.gameObject.layer == targetLayer && collider.isTrigger == false)
            {
                distant = Vector2.Distance(collider.transform.position, transform.position);

                if (closestEnemy == null)
                {
                    closestEnemy = damagable;
                    minDistant = distant;
                }
                else
                {
                    if (distant < minDistant)
                    {
                        closestEnemy = damagable;
                        minDistant = distant;
                    }
                }
            }
        }

        return closestEnemy;
    }
}