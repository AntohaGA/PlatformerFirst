using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private bool isPlayerIn = false;

    public event Action<PlayerMovement> CheckedPlayer;
    public event Action LostPlayer;
    public event Action Attacked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayerIn == false && collision.TryGetComponent(out PlayerMovement player))
        {
            isPlayerIn = true;
            CheckedPlayer?.Invoke(player);  
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isPlayerIn && collision.GetComponent<PlayerMovement>())
        {
            isPlayerIn = false;
            LostPlayer?.Invoke();
        }
    }
}