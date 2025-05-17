using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    public event Action JumpPressed;
    public event Action<float> MovePressed;
    public event Action AttackPressed;

    public void Update()
    {
        if (Input.GetAxis(Horizontal) != 0)
            MovePressed?.Invoke(Input.GetAxis(Horizontal));

        if (Input.GetKeyDown(KeyCode.Space))
            JumpPressed?.Invoke();

        if (Input.GetKeyUp(KeyCode.F))
            AttackPressed?.Invoke();
    }
}