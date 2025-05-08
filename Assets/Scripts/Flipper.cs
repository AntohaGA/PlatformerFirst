using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Vector3 _scaleRight;
    private Vector3 _scaleLeft;
     
    private void Awake()
    {
        _scaleRight = transform.localScale;
        _scaleLeft = transform.localScale;
        _scaleLeft.x *= -1;
    }

    public void SetDirection(float direction)
    {
        if (direction < 0)
            transform.localScale = _scaleLeft;
        else
            transform.localScale = _scaleRight;
    }
}