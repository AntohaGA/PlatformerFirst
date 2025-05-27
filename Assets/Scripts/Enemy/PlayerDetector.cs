using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerDetector : MonoBehaviour
{
    public event Action<Transform> CheckedPlayer;
    public event Action LostPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerAction player))
            CheckedPlayer?.Invoke(player.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerAction>())
            LostPlayer?.Invoke();
    }
}