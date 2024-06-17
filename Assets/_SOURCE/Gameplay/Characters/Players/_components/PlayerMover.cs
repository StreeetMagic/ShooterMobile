using Gameplay.Stats;
using Infrastructure.ConfigServices;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerMover : IProgressWriter
  {
    private readonly CharacterController _characterController;
    private readonly PlayerStatsProvider _playerStatsProvider;
    private readonly ConfigProvider _configProvider;

    private Vector3 _cachedVelocity;
    private Vector3 _gravitySpeed;

    public PlayerMover(CharacterController characterController,
      PlayerStatsProvider playerStatsProvider,
      ConfigProvider configProvider)
    {
      _characterController = characterController;
      _playerStatsProvider = playerStatsProvider;
      _configProvider = configProvider;
    }

    public void Move(Vector3 directionXYZ)
    {
      Vector3 playerSpeed = directionXYZ * (_playerStatsProvider.GetStat(StatId.MoveSpeed) * Time.deltaTime);

      // if (directionXYZ.magnitude > 0.01)
      //   _playerAnimator.PlayRunAnimation();
      // else
      //   _playerAnimator.Stop();

      if (_characterController.isGrounded)
      {
        _cachedVelocity = playerSpeed;
        _characterController.Move(playerSpeed + Vector3.down);
        _gravitySpeed = Vector3.zero;
      }
      else
      {
        ApplyGravity();
        _characterController.Move(_cachedVelocity + _gravitySpeed);
      }
    }

    public void ReadProgress(ProjectProgress projectProgress)
    {
      // if (_characterController == null)
      //   return;
      //
      // _characterController.enabled = false;
      // Transform.position = projectProgress.PlayerPosition;
      // _characterController.enabled = true;
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      // projectProgress.PlayerPosition = Transform.position;
    }

    private void ApplyGravity()
    {
      _gravitySpeed += Physics.gravity * _configProvider.PlayerConfig.GravityScale * Time.deltaTime;
    }
  }
}