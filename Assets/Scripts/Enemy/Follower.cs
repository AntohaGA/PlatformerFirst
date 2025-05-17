using System;
using UnityEngine;

[RequireComponent(typeof(PlayerDetector))]
public class Follower : MonoBehaviour
{
    private PlayerDetector _detector;
    private PlayerMovement _player;

    private void Awake()
    {
        _detector = GetComponent<PlayerDetector>();

        _detector.CheckedPlayer += SetTarget;
        _detector.LostPlayer += RemoveTarget;
    }

    public float GetDirection()
    {
        if (_player != null)
        {
            return Math.Sign(_player.transform.position.x - transform.position.x);
        }

        return 0;
    }

    private void SetTarget(PlayerMovement player)
    {
        _player = player;
    }

    private void RemoveTarget()
    {
        _player = null;
    }
}