using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerRender))]
public class Player : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerRender _playerRender;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerRender = GetComponent<PlayerRender>();
    }

    private void Update()
    {
        _playerRender.UpdateAnimation(_playerMovement.CurrentDirection, _playerMovement.IsJump);
    }

    private void FixedUpdate()
    {
        _playerMovement.Move();
    }
}