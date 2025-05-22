using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerDetector : MonoBehaviour
{
    public event Action<PlayerMovement> CheckedPlayer;
    public event Action LostPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement player) && collision.isTrigger == false)
        {
            CheckedPlayer?.Invoke(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() && collision.isTrigger == false)
        {
            LostPlayer?.Invoke();
        }
    }
}