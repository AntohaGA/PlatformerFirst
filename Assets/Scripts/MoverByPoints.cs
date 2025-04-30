using System.Collections;
using UnityEngine;

public class MoverByPoints : MonoBehaviour
{
    private const float MinDistant = 0.5f;
    private const int Turn = 180;

    [SerializeField] private Transform[] _points;

    [SerializeField] private float _speed;

    private int _numberNextPoint = 0;

    private Transform _nextPoint;

    private void Awake()
    {
        StartCoroutine(PatrolBetweenTwoPoints());
    }

    private IEnumerator PatrolBetweenTwoPoints()
    {
        Vector3 rotate = transform.eulerAngles;

        while (true)
        {
            yield return null;

            _nextPoint = _points[_numberNextPoint];
            transform.position = Vector2.MoveTowards(transform.position, _nextPoint.position, _speed * Time.deltaTime);

            if ((transform.position - _nextPoint.position).magnitude < MinDistant)
            {
                _numberNextPoint = ++_numberNextPoint % _points.Length;
                rotate.y += Turn;
                transform.rotation = Quaternion.Euler(rotate);
            }
        }
    }
}