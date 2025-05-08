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
        _playerRender.SetParameters(_playerMovement.CurrentDirection, _playerMovement.IsJump);
    }
}