using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const KeyCode Jump = KeyCode.Space;
    private const KeyCode Attack = KeyCode.F;
    private const KeyCode Vampirism = KeyCode.V;

    public event Action JumpPressed;
    public event Action<float> MovePressed;
    public event Action AttackPressed;
    public event Action VampirismPressed;

    public void Update()
    {
        if (Input.GetAxis(Horizontal) != 0)
            MovePressed?.Invoke(Input.GetAxis(Horizontal));

        if (Input.GetKeyDown(Jump))
            JumpPressed?.Invoke();

        if (Input.GetKeyUp(Attack))
            AttackPressed?.Invoke();

        if(Input.GetKeyUp(Vampirism))
            VampirismPressed?.Invoke();
    }
}