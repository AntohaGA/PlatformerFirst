using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class AttackDetector : MonoBehaviour
{
    public event Action AttackPlayer;
    public event Action LostAttackPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement player))
            AttackPlayer?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
            LostAttackPlayer?.Invoke();
    }
}