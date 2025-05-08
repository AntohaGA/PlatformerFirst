using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    const float CheckGroundDistant = 0.1f;

    public bool IsGround { get; private set; }

    private void Update()
    {
        if (CheckGround())
            IsGround = true;
        else
            IsGround = false;
    }

    private bool CheckGround()
    {
        return (Physics2D.Raycast(transform.position, -Vector2.up, CheckGroundDistant).collider != null);
    }
}