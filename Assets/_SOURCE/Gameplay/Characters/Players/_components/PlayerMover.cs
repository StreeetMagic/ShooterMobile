using Gameplay.Characters.Players.Animators;
using Gameplay.Stats;
using PersistentProgresses;
using SaveLoadServices;
using StaticDataServices;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerMover : IProgressWriter
  {
    private readonly PlayerAnimator _playerAnimator;
    private readonly CharacterController _characterController;
    private readonly PlayerStatsProvider _playerStatsProvider;
    private readonly IStaticDataService _staticDataService;
    private readonly PlayerProvider _playerProvider;

    private Vector3 _cachedVelocity;
    private Vector3 _gravitySpeed;

    public PlayerMover(
      PlayerAnimator playerAnimator,
      CharacterController characterController,
      PlayerStatsProvider playerStatsProvider,
      IStaticDataService staticDataService,
      PlayerProvider playerProvider)
    {
      _playerAnimator = playerAnimator;
      _characterController = characterController;
      _playerStatsProvider = playerStatsProvider;
      _staticDataService = staticDataService;
      _playerProvider = playerProvider;
    }

    private PlayerConfig PlayerConfig => _staticDataService.GetPlayerConfig();
    private float MoveSpeed => _playerStatsProvider.GetStat(StatId.MoveSpeed).Value;
    private float GravityScale => PlayerConfig.GravityScale;
    private Transform Transform => _playerProvider.Transform;

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
      _gravitySpeed += Physics.gravity * GravityScale * Time.deltaTime;
    }
  }
}