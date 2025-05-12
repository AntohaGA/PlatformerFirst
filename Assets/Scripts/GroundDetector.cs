using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public event Action Landed;
    public event Action Jumped;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ground>())
            Landed?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Ground>())
            Jumped?.Invoke();
    }
}