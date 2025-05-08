using UnityEngine;

public class PatrolByPoints : MonoBehaviour
{
    private const float MinDistant = 0.5f;

    [SerializeField] private Transform[] _points;

    private int _numberNextPoint = 0;
    private Transform _nextPoint;

    public float GetDirection()
    {
        if (GetNextPoint().position.x > transform.position.x)
            return 1;
        else
            return -1;
    }
    private Transform GetNextPoint()
    {
        _nextPoint = _points[_numberNextPoint];

        if ((transform.position - _nextPoint.position).magnitude < MinDistant)
        {
            _numberNextPoint = ++_numberNextPoint % _points.Length;
        }

        return _nextPoint;
    }
}