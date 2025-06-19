using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerDetector : MonoBehaviour
{
    private int _countPlayerIn = 0;  

    public event Action<Transform> CheckedPlayer;
    public event Action LostPlayer;
    public event Action AttackPlayer;
    public event Action LostAttackPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerAction player))
        {
            _countPlayerIn++;

            if(_countPlayerIn == 1)
            {
                CheckedPlayer?.Invoke(player.transform);
            }
            else 

            if(_countPlayerIn == 2)
            {
                AttackPlayer?.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerAction>())
        {
            _countPlayerIn--;

            if(_countPlayerIn == 0)
            {
                LostPlayer?.Invoke();
            }
            else 
            
            if(_countPlayerIn == 1)
            {
                LostAttackPlayer?.Invoke();
            }
        }
    }
}