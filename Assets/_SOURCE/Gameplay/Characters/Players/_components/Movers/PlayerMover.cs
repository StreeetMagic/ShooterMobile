using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.PlayerStatsProviders;
using Gameplay.Stats;
using Loggers;
using Projects;
using SaveLoadServices;
using StaticDataServices;
using UnityEngine;

namespace Gameplay.Characters.Players.Movers
{
  public class PlayerMover : IProgressWriter
  {
    private readonly PlayerAnimator _playerAnimator;
    private readonly CharacterController _characterController;
    private readonly PlayerStatsProvider _playerStatsProvider;
    private readonly IStaticDataService _staticDataService;
    private readonly Transform _transform;

    private Vector3 _cachedVelocity;
    private Vector3 _gravitySpeed;

    public PlayerMover(
      PlayerAnimator playerAnimator,
      CharacterController characterController,
      PlayerStatsProvider playerStatsProvider,
      IStaticDataService staticDataService,
      Transform playerTransform)
    {
      _playerAnimator = playerAnimator;
      _characterController = characterController;
      _playerStatsProvider = playerStatsProvider;
      _staticDataService = staticDataService;
      _transform = playerTransform;
    }

    private PlayerConfig PlayerConfig => _staticDataService.GetPlayerConfig();
    private float MoveSpeed => _playerStatsProvider.GetStat(StatId.MoveSpeed).Value;
    private float GravityScale => PlayerConfig.GravityScale;

    public void Move(Vector3 directionXYZ)
    {
      Vector3 playerSpeed = directionXYZ * (MoveSpeed * Time.deltaTime);

      if (directionXYZ.magnitude > 0.01)
        _playerAnimator.PlayRunAnimation();
      else
        _playerAnimator.Stop();

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
      if (_characterController == null)
        return;

      _characterController.enabled = false;
      _transform.position = projectProgress.PlayerPosition;
      _characterController.enabled = true;
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      new DebugLogger().Log($"Player position: {_transform.position}");
      projectProgress.PlayerPosition = _transform.position;
    }

    private void ApplyGravity()
    {
      _gravitySpeed += Physics.gravity * GravityScale * Time.deltaTime;
    }
  }
}