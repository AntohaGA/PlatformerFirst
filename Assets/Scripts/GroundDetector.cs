using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GroundDetector : MonoBehaviour
{
    private int _countGround = 0;
    public event Action Landed;
    public event Action Falling;
    public bool InAir { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ground>())
        {
            Landed?.Invoke();
            _countGround++;         
            InAir = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Ground>())
        {
            _countGround--;

            if (_countGround == 0)
            {
                InAir = true;
                Falling?.Invoke();
            }
        }
    }
}