using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    public event Action JumpPressed;
    public event Action<float> MovePressed;

    public void Update()
    {
        if (Input.GetAxis(Horizontal) != 0)
            MovePressed?.Invoke(Input.GetAxis(Horizontal));

        if (Input.GetKeyDown(KeyCode.Space))
            JumpPressed?.Invoke();
    }
}