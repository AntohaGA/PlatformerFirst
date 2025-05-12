using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool InAir { get;private  set; }

    public event Action Landed;
    public event Action Jumped;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ground>())
        {
            Landed?.Invoke();
            InAir = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Ground>())
        {
            Jumped?.Invoke();
            InAir = true;
        }
    }
}