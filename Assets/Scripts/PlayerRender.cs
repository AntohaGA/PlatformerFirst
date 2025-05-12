using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(GroundDetector))]
public class PlayerRender : MonoBehaviour
{
    private static int s_speed = Animator.StringToHash("speed");
    private static int s_isJump = Animator.StringToHash("isJump");

    private Animator _animator;
    private Flipper _flipper;
    private InputReader _inputReader;
    private GroundDetector _groundDetector;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _flipper = GetComponent<Flipper>();
        _inputReader = GetComponent<InputReader>();
        _groundDetector = GetComponent<GroundDetector>();

        _inputReader.MovePressed += Move;
        _groundDetector.Landed += LandAnimation;
        _groundDetector.Jumped += JumpAnimation;
    }

    private void Move(float direction)
    {
        _flipper.SetDirection(direction);
        _animator.SetFloat(s_speed, Mathf.Abs(direction));
    }

    private void LandAnimation()
    {
        _animator.SetBool(s_isJump, false);
    }

    private void JumpAnimation()
    {
        _animator.SetBool(s_isJump, true);
    }
}