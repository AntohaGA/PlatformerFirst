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

    private enum _state
    {
        STATE_PATROOL,
        STATE_ATTACK
    };

    private _state _enemyState;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _patrolByPoints = GetComponent<PatrolByPoints>();
        _flipper = GetComponent<Flipper>();

        _enemyState = _state.STATE_PATROOL;
    }

    private void FixedUpdate()
    {
        _flipper.SetDirection(_direction);

        switch (_enemyState)
        {
            case _state.STATE_PATROOL:
                MoveByPoints();
                break;

            case _state.STATE_ATTACK:
                AttackPlayer();
                break;
        }
    }

    private void MoveByPoints()
    {
        _direction = _patrolByPoints.GetDirection();
        _mover.Move(_direction);
    }

    private void AttackPlayer()
    {

    }

    private _state GetState()
    {
        return 0;
    }
}