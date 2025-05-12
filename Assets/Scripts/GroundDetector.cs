using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool InAir { get;private  set; }

    public event Action Landed;
    public event Action Falling;

    private int _countGround = 0;

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