using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(PatrolByPoints))]
[RequireComponent(typeof(Flipper))]
public class Enemy : MonoBehaviour
{
    private Mover _mover;
    private PatrolByPoints _patrolByPoints;
    private Flipper _flipper;

    private float _direction;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _patrolByPoints = GetComponent<PatrolByPoints>();
        _flipper = GetComponent<Flipper>();
    }

    private void FixedUpdate()
    {
        _flipper.SetDirection(_direction);
        MoveByPoints();
    }

    private void MoveByPoints()
    {
        _direction = _patrolByPoints.GetDirection();
        _mover.Move(_direction);
    }
}