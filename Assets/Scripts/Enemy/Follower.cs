using System;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private PlayerDetector _detector;
    private Transform _playerTransform;

    private void Awake()
    {
        _detector = GetComponentInChildren<PlayerDetector>();

        _detector.CheckedPlayer += SetTarget;
        _detector.LostPlayer += RemoveTarget;
    }

    public float GetDirection()
    {
        if (_playerTransform != null)
            return Math.Sign(_playerTransform.position.x - transform.position.x);

        return 0;
    }

    private void SetTarget(Transform player)
    {
        _playerTransform = player;
    }

    private void RemoveTarget()
    {
        _playerTransform = null;
    }
}