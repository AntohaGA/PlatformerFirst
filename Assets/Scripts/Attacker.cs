using UnityEngine;

public class Attacker : MonoBehaviour
{
    public void Hit(float damage, Vector2 attackArea)
    {
        Vector2 attackDirection = transform.position;
        Vector2 currentPos = transform.position;

        attackArea.x *= transform.right.x;
        attackArea += currentPos;

        attackDirection *= transform.right.x;

        RaycastHit2D hit = Physics2D.CircleCast(attackArea, 0.5f, attackDirection, 1f);

        Debug.Log(hit.collider);

        if (hit.collider.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
        }
    }
}