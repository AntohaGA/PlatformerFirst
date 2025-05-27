using UnityEngine;

public class Flipper : MonoBehaviour
{
    private const float RotateAngle = 180;

    private Quaternion _rotateRight;
    private Quaternion _rotateLeft;

    private void Awake()
    {
        _rotateRight = transform.rotation;
        _rotateLeft = transform.rotation;
        _rotateLeft.y += RotateAngle;
    }

    public void SetDirection(float direction)
    {
        if (direction < 0)
            transform.rotation = _rotateLeft;
        else
            transform.rotation = _rotateRight;
    }
}